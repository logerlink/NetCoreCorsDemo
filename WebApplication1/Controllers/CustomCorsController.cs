using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// EnableCors修饰类
    /// </summary>
    [ApiController]
    [Route("CustomCors")]
    [EnableCors("MyPolicy")]
    public class CustomCorsController : Controller
    {
        [HttpGet("Index1")]
        public string Index1()
        {
            return "支持跨域的请求1";
        }
        [HttpGet("Index2")]
        public string Index2()
        {
            return "支持跨域的请求2";
        }
        /// <summary>
        /// DisableCors 特性表明不支持跨域  如果修饰类，则表明该类中的所有Action不支持跨域
        /// </summary>
        /// <returns></returns>
        [HttpGet("Index3")]
        [DisableCors]
        public string Index3()
        {
            return "不支持跨域的请求2";
        }
    }
}
