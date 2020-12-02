using MediSmartApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UserDataAccess;


namespace MediSmartApi.Controllers
{
    [RoutePrefix("api")]
    public class RegistrationController : ApiController
    {
        [HttpPost]
        [Route("postUser")]
        public IHttpActionResult postUserData(RegistrationDetail userDetail)
        {
            try
            {
                MediSmartProjectEntities _userDetails = new MediSmartProjectEntities();
                if (userDetail == null)
                {
                    return BadRequest();
                };

             

              _userDetails.RegistrationDetails.Add(userDetail);
                _userDetails.SaveChanges();

                return Content(HttpStatusCode.OK, 0);




            }
            catch(Exception ex)
            {
                return InternalServerError();
            }

        }

        [HttpPost]
        [Route("updateUser")]
        public IHttpActionResult updateUserData(RegistrationDetail userDetail)
        {
            try
            {
                MediSmartProjectEntities _userDetails = new MediSmartProjectEntities();
                if (userDetail == null)
                {
                    return BadRequest();
                };

                var user = _userDetails.RegistrationDetails.Where(p => p.itbid == userDetail.itbid).FirstOrDefault();

                if(user != null)
                {
                    user.FirstName = userDetail.FirstName;
                    user.LastName = userDetail.LastName;
                    user.OtherName = userDetail.OtherName;
                    user.MaidenName = userDetail.MaidenName;
                    user.Sex = userDetail.Sex;
                    user.PhoneNumber = userDetail.PhoneNumber;
                    user.Address = userDetail.Address;
                    user.State = userDetail.State;
                    user.Next_Of_Kin = userDetail.Next_Of_Kin;
                    user.Email = userDetail.Email;

                }
                else
                {
                    return BadRequest();

                }
                _userDetails.SaveChanges();

                return Content(HttpStatusCode.OK, 0);




            }
            catch (Exception ex)
            {
                return InternalServerError();
            }

        }




        [HttpGet]
        [Route("GetUsers")]

        public async Task< IHttpActionResult>  Get()
        {
            try
            {
                MediSmartProjectEntities _userDetails = new MediSmartProjectEntities();

                var regList = (from s in _userDetails.RegistrationDetails.ToList()
                                        select new Registration
                                       {
                                         FirstName = s.FirstName,
                                         LastName = s.LastName,
                                         OtherName = s.OtherName,
                                         MaidenName = s.MaidenName,
                                         Sex = s.Sex,
                                         PhoneNumber = s.PhoneNumber,
                                         Address = s.Address,
                                         State = s.State,
                                         Next_Of_Kin = s.Next_Of_Kin,
                                         Email = s.Email,
                                         itbid = s.itbid
                                         
                                        

                                        }).ToList();

                return Ok(regList);
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("DeleteUser/{itbId}")]
        public async Task<IHttpActionResult> deleteUser(int itbId)
        {
            try
            {
                MediSmartProjectEntities _userDetails = new MediSmartProjectEntities();
                var _user = _userDetails.RegistrationDetails.Where(p => p.itbid == itbId).FirstOrDefault();

                if(_user != null)
                {
                    _userDetails.RegistrationDetails.Remove(_user);
                    _userDetails.SaveChanges();
                    return Content(HttpStatusCode.OK, 0);

                }
                else
                {
                    return BadRequest();
                }


            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
        }
        


        





       



    }
}
