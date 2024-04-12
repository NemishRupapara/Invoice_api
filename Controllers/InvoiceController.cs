using InvoiceAppApi.Dto;
using InvoiceAppApi.Interffaces;
using InvoiceAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAppApi.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IcustomerRepository _icustomerRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository,IcustomerRepository icustomerRepository) 
        {
            _invoiceRepository = invoiceRepository;
            _icustomerRepository = icustomerRepository;
        }


        [Route("AddInvoice")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddInvoice([FromBody] InvoiceDto Invoice )
        {
            if (Invoice == null)
                return BadRequest(ModelState);

            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

         

            if (!_invoiceRepository.AddInvoice(Invoice))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }


        [Route("GetcustomerList")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetCountries()
        {
            var CustomerList = _icustomerRepository.GetCustomerList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(CustomerList);
        }

        [Route("GetItemList")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ItemName>))]
        public IActionResult GetItemList()
        {
            var ItemList = _icustomerRepository.GetItemList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(ItemList);
        }
        [Route("GetMenuList")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MenuModel>))]
        public IActionResult GetMenuList()
        {
            var ItemList = _icustomerRepository.GetAllMenuList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(ItemList);
        }

        [Route("GetPaymentModeList")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PaymentModeModel>))]
        public IActionResult GetPaymentModeList()
        {
            var PaymentModeList = _icustomerRepository.GetPaymentModeList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(PaymentModeList);
        }
        [Route("GetPaymentModeList2")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PaymentModeModel>))]
        public IActionResult GetPaymentModeLis2t()
        {
            var PaymentModeList = _icustomerRepository.GetPaymentModeList2();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(PaymentModeList);
        }
        [Route("GetRoleList")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RoleClass>))]
        public IActionResult GetRoleList()
        {
            var RoleList = _icustomerRepository.GetRoleList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(RoleList);
        }

        [Route("GetRolePermissions/{RoleID}")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Rolepermissions>))]
        public IActionResult GetRolePermissions(int RoleID)
        {
            var RoleList = _icustomerRepository.GetRolePermissions(RoleID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(RoleList);
        }


        [Route("GetUserPermission/{RoleID}")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Rolepermissions>))]
        public IActionResult GetUserPermission(int RoleID)
        {
            var RoleList = _icustomerRepository.GetUserPermission(RoleID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(RoleList);
        }


        [Route("GetAllUserList")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User2>))]
        public IActionResult GetAllUserList()
        {
            var UserList = _icustomerRepository.GetAllUserList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(UserList);
        }



        //[Route("GetInvoiceList")]
        [HttpGet("GetInvoiceList/{UserID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InvoiceClass>))]

        public IActionResult GetInvoiceList(int UserID)
        {
            var InvoiceList = _invoiceRepository.GetInvoiceList(UserID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(InvoiceList);
        }

        [HttpGet("GetInvoicePaymentList/{PaymentID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InvoiceClass>))]

        public IActionResult GetInvoicePaymentList(int PaymentID)
        {
            var InvoiceList = _invoiceRepository.GetInvoicePaymentForEdit(PaymentID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(InvoiceList);
        }

        [HttpGet("GetPaymentDetailForEdit/{PaymentID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InvoiceClass>))]

        public IActionResult GetPaymentDetailForEdit(int PaymentID)
        {
            var InvoiceList = _invoiceRepository.GetPaymentDetailForEdit(PaymentID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(InvoiceList);
        }

        [HttpGet("GetAllInvoiceList")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InvoiceClass>))]

        public IActionResult GetAllInvoiceList()
        {
            var InvoiceList = _invoiceRepository.GetAllInvoiceList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(InvoiceList);
        }

        [HttpGet("GetAllPaymentDetailList/{userID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PaymentDetails>))]

        public IActionResult GetAllPaymentDetailList(int userID)
        {
            var InvoiceList = _invoiceRepository.GetAllPaymentDetailsList(userID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(InvoiceList);
        }


        [HttpGet("{InvoiceID}")]

        public IActionResult GetEditInvoiceDetail1(int InvoiceID)
        {
            var InvoiceList = _invoiceRepository.GetEditInvoiceDetail(InvoiceID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(InvoiceList);
        }


        [Route("GetInvoiceListOfCustomer")]

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult GetInvoiceListOfCustomer([FromBody] CustomerPayment Customer)
        {
            if (Customer == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var invoices = _invoiceRepository.GetInvoiceListOfCustomer(Customer);

            return Ok(invoices);
        }



        [HttpGet("GetSinglePaymentDetail/{InvoiceID}")]

        public IActionResult GetSinglePaymentDetail(int InvoiceID)
        {
            var InvoiceList = _invoiceRepository.GetSinglePaymentdetail(InvoiceID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(InvoiceList);
        }


        [Route("EditInvoice")]

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult EditInvoice([FromBody] InvoiceDto Invoice)
        {
            if (Invoice == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_invoiceRepository.EditInvoice(Invoice))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }



        [Route("EditPayment")]

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult EditPayment([FromBody] MultiplePayment_ViewModel Invoice)
        {
            if (Invoice == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_invoiceRepository.EditPaymentDetails(Invoice))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }


        [Route("EditSinglePayment")]

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult EditSinglePayment([FromBody] Payment payment)
        {
            if (payment == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_invoiceRepository.EditSinglePayment(payment))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }

        [Route("EditMultiplePayment")]

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult EditMultiplePayment([FromBody] MultiplePayment_ViewModel payment)
        {
            if (payment == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_invoiceRepository.EditMultiplePayment(payment))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }

        [HttpDelete("DeleteInvoice/{InvoiceID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteInvoice(int InvoiceID)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            if (!_invoiceRepository.DeleteInvoice(InvoiceID))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("DeletePayment/{PaymentID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePayment(int PaymentID)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            if (!_invoiceRepository.DeletePayment(PaymentID))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
