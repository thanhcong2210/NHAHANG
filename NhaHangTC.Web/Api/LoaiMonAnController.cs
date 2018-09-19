using AutoMapper;
using NhaHangTC.Model.Models;
using NhaHangTC.Service;
using NhaHangTC.Web.Infrastructure.Core;
using NhaHangTC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace NhaHangTC.Web.Api
{
        // GET api/<controller>
        [RoutePrefix("api/loaimonan")]
        [Authorize]
        public class LoaiMonAnController : ApiControllerBase
        {
            #region Initialize
            private ILoaiMonAnService _productCategoryService;

            public LoaiMonAnController(IErrorService errorService, ILoaiMonAnService productCategoryService)
                : base(errorService)
            {
                this._productCategoryService = productCategoryService;
            }

            #endregion

            [Route("getallparents")]
            [HttpGet]
            public HttpResponseMessage GetAll(HttpRequestMessage request)
            {
                return CreateHttpResponse(request, () =>
                {
                    var model = _productCategoryService.GetAll();

                    var responseData = Mapper.Map<IEnumerable<LoaiMonAn>, IEnumerable<LoaiMonAnViewModel>>(model);

                    var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                    return response;
                });
            }
            [Route("getbyid/{id:int}")]
            [HttpGet]
            public HttpResponseMessage GetById(HttpRequestMessage request, int id)
            {
                return CreateHttpResponse(request, () =>
                {
                    var model = _productCategoryService.GetById(id);

                    var responseData = Mapper.Map<LoaiMonAn, LoaiMonAnViewModel>(model);

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
                    var model = _productCategoryService.GetAll(keyword);

                    totalRow = model.Count();
                    var query = model.OrderByDescending(x => x.MALOAI).Skip(page * pageSize).Take(pageSize);

                    var responseData = Mapper.Map<IEnumerable<LoaiMonAn>, IEnumerable<LoaiMonAnViewModel>>(query);

                    var paginationSet = new PaginationSet<LoaiMonAnViewModel>()
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
            [AllowAnonymous]
            public HttpResponseMessage Create(HttpRequestMessage request, LoaiMonAnViewModel productCategoryVm)
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
                        var newProductCategory = new LoaiMonAn();
                        newProductCategory.UpdateLoaiMonAn(productCategoryVm);
                        //newProductCategory.CreatedDate = DateTime.Now;
                        _productCategoryService.Add(newProductCategory);
                        _productCategoryService.Save();

                        var responseData = Mapper.Map<LoaiMonAn, LoaiMonAnViewModel>(newProductCategory);
                        response = request.CreateResponse(HttpStatusCode.Created, responseData);
                    }

                    return response;
                });
            }

            //[Route("update")]
            //[HttpPut]
            //[AllowAnonymous]
            //public HttpResponseMessage Update(HttpRequestMessage request, LoaiMonAnViewModel productCategoryVm)
            //{
            //    return CreateHttpResponse(request, () =>
            //    {
            //        HttpResponseMessage response = null;
            //        if (!ModelState.IsValid)
            //        {
            //            response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            //        }
            //        else
            //        {
            //            var dbProductCategory = LoaiMonAnService.GetById(productCategoryVm.MALOAI);

            //            dbProductCategory.UpdateLoaiMonAn(productCategoryVm);
            //            //dbProductCategory. = DateTime.Now;

            //            _productCategoryService.Update(dbProductCategory);
            //            _productCategoryService.Save();

            //            var responseData = Mapper.Map<LoaiMonAn, LoaiMonAnViewModel>(dbProductCategory);
            //            response = request.CreateResponse(HttpStatusCode.Created, responseData);
            //        }

            //        return response;
            //    });
            //}

            [Route("delete")]
            [HttpDelete]
            [AllowAnonymous]
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
                        var oldProductCategory = _productCategoryService.Delete(id);
                        _productCategoryService.Save();

                        var responseData = Mapper.Map<LoaiMonAn, LoaiMonAnViewModel>(oldProductCategory);
                        response = request.CreateResponse(HttpStatusCode.Created, responseData);
                    }

                    return response;
                });
            }
            [Route("deletemulti")]
            [HttpDelete]
            [AllowAnonymous]
            public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProductCategories)
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
                        var listProductCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedProductCategories);
                        foreach (var item in listProductCategory)
                        {
                            _productCategoryService.Delete(item);
                        }

                        _productCategoryService.Save();

                        response = request.CreateResponse(HttpStatusCode.OK, listProductCategory.Count);
                    }

                    return response;
                });
            }
        }
}