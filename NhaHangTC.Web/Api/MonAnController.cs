using NhaHangTC.Model.Models;
using NhaHangTC.Service;
using NhaHangTC.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NhaHangTC.Web.Models;
using AutoMapper;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using NhaHangTC.Common;
using OfficeOpenXml;

namespace NhaHangTC.Web.Api
{
    [RoutePrefix("api/monan")]
    [Authorize]
    public class MonAnController : ApiControllerBase
    {
        #region Initialize
        private IMonAnService _monAnService;

        public MonAnController(IErrorService errorService, IMonAnService monAnService)
            : base(errorService)
        {
            this._monAnService = monAnService;
        }

        #endregion

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            Func<HttpResponseMessage> func = () =>
            {
                var model = _monAnService.GetAll();

                var responseData = Mapper.Map<IEnumerable<MonAn>, IEnumerable<MonAnViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            };
            return CreateHttpResponse(request, func);
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _monAnService.GetById(id);

                var responseData = Mapper.Map<MonAn, MonAnViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _monAnService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.NGAYTAOMOI).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<MonAn>, IEnumerable<MonAnViewModel>>(query.AsEnumerable());

                var paginationSet = new PaginationSet<MonAnViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }


        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, MonAnViewModel MonAnCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newMonAn = new MonAn();
                    newMonAn.UpdateMonAn(MonAnCategoryVm);
                    newMonAn.NGAYTAOMOI = DateTime.Now;
                    //newMonAn.CreatedBy = User.Identity.Name;
                    _monAnService.Add(newMonAn);
                    _monAnService.Save();

                    var responseData = Mapper.Map<MonAn, MonAnViewModel>(newMonAn);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, MonAnViewModel MonAnVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbMonAn = _monAnService.GetById(MonAnVm.MAMON);

                    dbMonAn.UpdateMonAn(MonAnVm);
                    dbMonAn.NGAYTAOMOI = DateTime.Now;
                    //dbMonAn.UpdatedBy = User.Identity.Name;
                    _monAnService.Update(dbMonAn);
                    _monAnService.Save();

                    var responseData = Mapper.Map<MonAn, MonAnViewModel>(dbMonAn);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldMonAnCategory = _monAnService.Delete(id);
                    _monAnService.Save();

                    var responseData = Mapper.Map<MonAn, MonAnViewModel>(oldMonAnCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedMonAns)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listMonAnCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedMonAns);
                    foreach (var item in listMonAnCategory)
                    {
                        _monAnService.Delete(item);
                    }

                    _monAnService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listMonAnCategory.Count);
                }

                return response;
            });
        }

        [Route("import")]
        [HttpPost]
        public async Task<HttpResponseMessage> Import()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, "Định dạng không được server hỗ trợ");
            }

            var root = HttpContext.Current.Server.MapPath("~/UploadedFiles/Excels");
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            var provider = new MultipartFormDataStreamProvider(root);
            var result = await Request.Content.ReadAsMultipartAsync(provider);
            //do stuff with files if you wish
            if (result.FormData["maLoai"] == null)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bạn chưa chọn danh mục sản phẩm.");
            }

            //Upload files
            int addedCount = 0;
            int categoryId = 0;
            int.TryParse(result.FormData["maLoai"], out categoryId);
            foreach (MultipartFileData fileData in result.FileData)
            {
                if (string.IsNullOrEmpty(fileData.Headers.ContentDisposition.FileName))
                {
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Yêu cầu không đúng định dạng");
                }
                string fileName = fileData.Headers.ContentDisposition.FileName;
                if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                {
                    fileName = fileName.Trim('"');
                }
                if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                {
                    fileName = Path.GetFileName(fileName);
                }

                var fullPath = Path.Combine(root, fileName);
                File.Copy(fileData.LocalFileName, fullPath, true);

                //insert to DB
                var listMonAn = this.ReadMonAnFromExcel(fullPath, categoryId);
                if (listMonAn.Count > 0)
                {
                    foreach (var MonAn in listMonAn)
                    {
                        _monAnService.Add(MonAn);
                        addedCount++;
                    }
                    _monAnService.Save();
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Đã nhập thành công " + addedCount + " sản phẩm thành công.");
        }

        [HttpGet]
        [Route("ExportXls")]
        public async Task<HttpResponseMessage> ExportXls(HttpRequestMessage request, string filter = null)
        {
            string fileName = string.Concat("MonAn_" + DateTime.Now.ToString("yyyyMMddhhmmsss") + ".xlsx");
            var folderReport = ConfigHelper.GetByKey("ReportFolder");
            string filePath = HttpContext.Current.Server.MapPath(folderReport);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string fullPath = Path.Combine(filePath, fileName);
            try
            {
                var data = _monAnService.GetListMonAn(filter).ToList();
                await ReportHelper.GenerateXls(data, fullPath);
                return request.CreateErrorResponse(HttpStatusCode.OK, Path.Combine(folderReport, fileName));
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("ExportPdf")]
        public async Task<HttpResponseMessage> ExportPdf(HttpRequestMessage request, int id)
        {
            string fileName = string.Concat("MonAn" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".pdf");
            var folderReport = ConfigHelper.GetByKey("ReportFolder");
            string filePath = HttpContext.Current.Server.MapPath(folderReport);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string fullPath = Path.Combine(filePath, fileName);
            try
            {
                var template = File.ReadAllText(HttpContext.Current.Server.MapPath("/Assets/admin/templates/MonAn-detail.html"));
                var replaces = new Dictionary<string, string>();
                var MonAn = _monAnService.GetById(id);

                replaces.Add("{{TENGOI}}", MonAn.TENGOI);
                replaces.Add("{{DONGIA}}", MonAn.DONGIA.ToString("N0"));
                replaces.Add("{{MOTA}}", MonAn.MOTA);
                //replaces.Add("{{Warranty}}", MonAn.Warranty + " tháng");

                //template = template.Parse(replaces); // ????????????

                await ReportHelper.GeneratePdf(template, fullPath);
                return request.CreateErrorResponse(HttpStatusCode.OK, Path.Combine(folderReport, fileName));
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        private List<MonAn> ReadMonAnFromExcel(string fullPath, int categoryId)
        {
            using (var package = new ExcelPackage(new FileInfo(fullPath)))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                List<MonAn> listMonAn = new List<MonAn>();
                MonAnViewModel MonAnViewModel;
                MonAn MonAn;

                //decimal originaldonGia = 0;
                float donGia = 0;
                //decimal promotiondonGia;


                //bool status = false;
                //bool showHome = false;
                //bool isHot = false;
                //int warranty;

                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    MonAnViewModel = new MonAnViewModel();
                    MonAn = new MonAn();

                    MonAnViewModel.TENGOI = workSheet.Cells[i, 1].Value.ToString();
                    //MonAnViewModel.Alias = StringHelper.ToUnsignString(MonAnViewModel.Name);
                    MonAnViewModel.MOTA = workSheet.Cells[i, 2].Value.ToString();

                    //if (int.TryParse(workSheet.Cells[i, 3].Value.ToString(), out warranty))
                    //{
                    //    MonAnViewModel.Warranty = warranty;

                    //}

                    //decimal.TryParse(workSheet.Cells[i, 4].Value.ToString().Replace(",", ""), out originaldonGia);
                    //MonAnViewModel.OriginaldonGia = originaldonGia;

                    float.TryParse(workSheet.Cells[i, 3].Value.ToString().Replace(",", ""), out donGia);
                    MonAnViewModel.DONGIA = donGia;

                    //if (decimal.TryParse(workSheet.Cells[i, 6].Value.ToString(), out promotiondonGia))
                    //{
                    //    MonAnViewModel.PromotiondonGia = promotiondonGia;

                    //}

                    MonAnViewModel.MOTA = workSheet.Cells[i, 4].Value.ToString();
                    MonAnViewModel.CACHLAM = workSheet.Cells[i, 5].Value.ToString();
                    //MonAnViewModel.MetaDescription = workSheet.Cells[i, 9].Value.ToString();

                    MonAnViewModel.MALOAI = categoryId;

                    //bool.TryParse(workSheet.Cells[i, 10].Value.ToString(), out status);
                    //MonAnViewModel.Status = status;

                    //bool.TryParse(workSheet.Cells[i, 11].Value.ToString(), out showHome);
                    //MonAnViewModel.HomeFlag = showHome;

                    //bool.TryParse(workSheet.Cells[i, 12].Value.ToString(), out isHot);
                    //MonAnViewModel.HotFlag = isHot;

                    MonAn.UpdateMonAn(MonAnViewModel);
                    listMonAn.Add(MonAn);
                }
                return listMonAn;
            }
        }
    }
}