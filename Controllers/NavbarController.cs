using InvoiceAppApi.Dto;
using InvoiceAppApi.Interffaces;
using InvoiceAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAppApi.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class NavbarController : Controller
    {

        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IcustomerRepository _icustomerRepository;

        public NavbarController(IInvoiceRepository invoiceRepository, IcustomerRepository icustomerRepository)
        {
            _invoiceRepository = invoiceRepository;
            _icustomerRepository = icustomerRepository;
        }
        [Route("EditItemName")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult EditItemName([FromBody] ItemName Item)
        {
            if (Item == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_icustomerRepository.EditItemName(Item))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }

        [Route("EditCustomerName")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult EditCustomerName([FromBody] Customer Customer)
        {
            if (Customer == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_icustomerRepository.EditCustomerName(Customer))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }

        [Route("EditRole")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult EditRole([FromBody] RoleClass Role)
        {
            if (Role == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_icustomerRepository.EditRoleName(Role))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }

        [Route("EditMenu")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult EditMenu([FromBody] MenuModel Menu)
        {
            if (Menu == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_icustomerRepository.EditMenu(Menu))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }

        [Route("EditPaymentMode")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult EditPaymentMode([FromBody] PaymentModeModel payment)
        {
            if (payment == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_icustomerRepository.EditPaymentModed(payment))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }



        [Route("EditUser")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult EditUser([FromBody] User User)
        {
            if (User == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_icustomerRepository.EditUser(User))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }



        [Route("EditPermissions")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult EditPermissions([FromBody] List<Rolepermissions> Permission)
        {
            if (Permission == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_icustomerRepository.EditPermissions(Permission))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }


        [Route("GiveRole")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult GiveRole([FromBody] GiveRole Role)
        {
            if (Role == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_icustomerRepository.GiveRole(Role))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }


        [HttpDelete("DeleteItemName/{ItemID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteItemName(int ItemID)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            if (!_icustomerRepository.DeleteItemName(ItemID))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
        [HttpDelete("DeleteCustomerName/{CustID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCustomerName(int CustID)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            if (!_icustomerRepository.DeleteCustomer(CustID))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
        [HttpDelete("DeleteMenu/{MenuID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteMenu(int MenuID)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            if (!_icustomerRepository.DeleteMenu(MenuID))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("DeleteRole/{RoleID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteRole(int RoleID)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            if (!_icustomerRepository.DeleteRole(RoleID))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
        [HttpDelete("DeletePaymentMode/{PaymentModeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePaymentMode(int PaymentModeId)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            if (!_icustomerRepository.DeletePaymentMode(PaymentModeId))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("DeleteUser/{UserID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int UserID)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            if (!_icustomerRepository.DeleteUser(UserID))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [Route("AddItemName")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddItemName([FromBody] ItemName Item)
        {
            if (Item == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_icustomerRepository.AddItemname(Item))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }

        [Route("AddCustomer")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_icustomerRepository.AddCustomer(customer))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }

        [Route("AddPaymentMode")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddPaymentMode([FromBody] PaymentModeModel payment)
        {
            if (payment == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_icustomerRepository.AddPaymentMode(payment))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }
        [Route("AddMenu")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddMenu([FromBody] MenuModel Menu)
        {
            if (Menu == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_icustomerRepository.AddMenu(Menu))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }

        [Route("AddRole")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddRole([FromBody] RoleClass Role)
        {
            if (Role == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_icustomerRepository.AddRole(Role))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }

        [Route("AddUser")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddUser([FromBody] User User)
        {
            if (User == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_icustomerRepository.AddUser(User))
            {
                ModelState.AddModelError("", "Something Went Wrong While Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }
    }
}
