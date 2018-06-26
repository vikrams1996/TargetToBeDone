using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using mallform.Models;
using System.Data.Entity;
using mallform.ViewModel;
using mallform.Dtos;
using AutoMapper;
namespace mallform.Controllers.Api
{
    public class RentController : ApiController
    {
        private ApplicationDbContext _Context;

        public RentController()
        {
            _Context = new ApplicationDbContext();
        }
        //GET/api/rent
        public IEnumerable<RentDto> GetRent()
        {
            return _Context.Rent.ToList().Select(Mapper.Map<Rent, RentDto>); //you are not gonna call this method
            // otherwise it gets executed  , remove parenthisis as a reference from source to target only.
        }

        //GET api/customers/Id

        public IHttpActionResult Rent (int Id)
        {

            var rent = _Context.Rent.SingleOrDefault(r => r.Id == Id);

            if (rent == null)
                return NotFound();

            return Ok( Mapper.Map<Rent, RentDto>(rent));
        }

        [HttpPost]
        public IHttpActionResult CreateRent (RentDto RentDto)
        {
            var rent = Mapper.Map<RentDto, Rent>(RentDto);

            _Context.Rent.Add(rent);
            _Context.SaveChanges();

            RentDto.Id = rent.Id; //ID is  generated in rent variable so we need to add this Id in our
            //DTO so we use this .

            return Created(new Uri(Request.RequestUri + "/" + rent.Id), RentDto);
        }

        //PUT //api/rent/1
        [HttpPut]
        public void UpdateRent (int id , RentDto RentDto)
        {

            var rentInDB = _Context.Rent.SingleOrDefault(r => r.Id == id);

                if(rentInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(RentDto , rentInDB);
          

            _Context.SaveChanges();


        }
        [HttpDelete]
        public void DeleteRent (int Id)
        {
            var rentInDB = _Context.Rent.SingleOrDefault(r => r.Id == Id);

            if (rentInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _Context.Rent.Remove(rentInDB);
            _Context.SaveChanges();


        }
    }
}
