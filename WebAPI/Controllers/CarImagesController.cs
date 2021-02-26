using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromForm] FileUpload objectFile, [FromForm] CarImage carImage)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(objectFile.files.FileName);
            string fileExtension = fileInfo.Extension;

            //var result = Guid.NewGuid().ToString() +
            //    "CAR-" + carId+  "-" + DateTime.Now.ToShortDateString()+ fileExtension;
         

            var path = Path.GetTempFileName();
            if (objectFile.files.Length > 0)
                using (var stream = new FileStream(path, FileMode.Create))
                    await objectFile.files.CopyToAsync(stream);
            var carimage = new CarImage { CarId = carImage.CarId, ImagePath = path, Date = DateTime.Now };
            var result = _carImageService.Add(carimage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult Getall()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        
        [HttpGet("getImagesById")]
        public IActionResult GetAllImagesByCarId(int Id)
        {
            var result = _carImageService.GetAllImagesByCarId(Id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
