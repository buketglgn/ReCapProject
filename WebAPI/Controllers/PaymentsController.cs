using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("add")]
        public IActionResult AddPayment(Payment payment)
        {
            var resultPayment = _paymentService.AddPayment(payment);
            if (resultPayment.Success)
            {
                return Ok(resultPayment);
            }
            else
            {
                return BadRequest(resultPayment);
            }


        }
    }
}
