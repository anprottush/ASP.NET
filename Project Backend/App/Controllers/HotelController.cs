﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.DTOs;
using BLL.Services;

namespace App.Controllers
{
    [EnableCors("*", "*", "*")]
    public class HotelController : ApiController
    {
        [HttpGet]
        [Route("api/hotels")]
        public HttpResponseMessage GetHotels()
        {
            return Request.CreateResponse(HttpStatusCode.OK, HotelService.GetAll());
        }

        [HttpGet]
        [Route("api/hotels/{id}")]
        public HttpResponseMessage GetHotel(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, HotelService.Get(id));
        }

        [HttpPost]
        [Route("api/hotels/add")]
        public HttpResponseMessage AddHotel(HotelDto hotelDto)
        {
            var hotel = HotelService.Add(hotelDto);
            return Request.CreateResponse(HttpStatusCode.OK, hotel);
        }

        [HttpPost]
        [Route("api/hotels/update")]
        public HttpResponseMessage UpdateHotel(HotelDto hotelDto)
        {
            var hotel = HotelService.Update(hotelDto);
            return Request.CreateResponse(HttpStatusCode.OK, hotel);
        }

        [Route("api/hotels/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {


            var data = HotelService.Delete(id);
            if (data != false)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "deleted");
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
