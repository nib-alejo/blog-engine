using Business;
using Common;
using Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : Controller
    {
        private readonly IBlogBL iBlogBL;

        public BlogController(IBlogBL iBlogBL)
        {
            this.iBlogBL = iBlogBL;
        }


        [HttpPost]
        public void Insert(Blog[] blogList)
        {
            try
            {
                iBlogBL.Insert(blogList);
            }
            catch (Exception)
            {
                // Exception must be handle by saving it in any kind of repository
            }
        }

        [HttpPut]
        public void Update(Blog[] blogList)
        {
            try
            {
                iBlogBL.Update(blogList);
            }
            catch (Exception)
            {
                // Exception must be handle by saving it in any kind of repository
            }
        }

        [HttpGet]
        public Blog[] GetByState(Guid stateId)
        {
            return iBlogBL.GetByState(stateId);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            try
            {
                iBlogBL.DeleteById(id);
            }
            catch (Exception)
            {
                // Exception must be handle by saving it in any kind of repository
            }
        }

        [HttpPut("ApproveOrReject")]
        public IActionResult ApproveOrReject(Guid id, Enums.Action action)
        {
            try
            {
                bool sw = iBlogBL.ApproveOrReject(id, action);

                if (sw)
                    return Ok();
                else
                    return StatusCode(422);
            }
            catch (Exception)
            {
                // Exception must be handle by saving it in any kind of repository
                return StatusCode(500);
            }
        }
    }
}
