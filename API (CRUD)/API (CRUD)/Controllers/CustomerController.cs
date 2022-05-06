using API__CRUD_.DataAccess;
using API__CRUD_.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API__CRUD_.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        IOrderDal _orderDal;
        ICustomerDal _customerDal;

        public CustomerController(IOrderDal orderDal, ICustomerDal customerDal)
        {
            _orderDal = orderDal;
            _customerDal = customerDal;
        }


        [HttpGet("GetCustomer")]
        public IActionResult GetCustomer()
        {
            return Ok(_customerDal.GetList());
        }



        [HttpGet("GetCustomer/{id?}")]
        public IActionResult GetCustomer(int id)
        {
            var product = _customerDal.Get(p => p.Idcustomer == id);

            try
            {
                if (product == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }

                else
                {
                    return Ok(_customerDal.GetList().Where(o => o.Idcustomer == id));
                }
            }
            catch (Exception)
            {

            }
            return BadRequest();

        }



        [HttpPost("PostCustomer")]
        public IActionResult PostCustomer([FromBody] Customers customer)
        {

            try
            {
                _customerDal.Add(customer);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }


        [HttpPut("PutCustomer")]
        public IActionResult PutCustomer([FromBody] Customers customer)
        {
            try
            {
                _customerDal.Update(customer);

                //return StatusCode(StatusCodes.Status200OK);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }


        [HttpDelete("DeleteCustomer/{id?}")]
        public IActionResult DeleteCustomer([FromBody] int customerId)
        {
            try
            {
                _customerDal.Delete(new Customers { Idcustomer = customerId });

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }









        [HttpGet("GetOrder")]
        public IActionResult GetOrder()
        {
            return Ok(_orderDal.GetList());
        }



        [HttpGet("GetOrder/{id?}")]
        public IActionResult GetOrder(int id)
        {
            var product = _orderDal.Get(p => p.Idorder == id);

            try
            {
                if (product == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }

                else
                {
                    return Ok(_orderDal.GetList().Where(o => o.Idorder == id));
                }
            }
            catch (Exception)
            {

            }
            return BadRequest();

        }




        [HttpGet("GetOrderbyCustomerId/{id?}")]
        public IActionResult GetOrderbyCustomerId(int id)
        {
            var product = _orderDal.GetList().Where(p => p.CustomerIdinOrders == id);

            try
            {
                if (product == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }

                else
                {
                    return Ok(_orderDal.GetList().Where(o => o.CustomerIdinOrders == id).ToList());
                }
            }
            catch (Exception)
            {

            }
            return BadRequest();

        }


        [HttpPost("PostOrder")]
        public IActionResult PostOrder([FromBody] Orders orders)
        {

            try
            {
                _orderDal.Add(orders);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }


        [HttpPut("OrderPut")]
        public IActionResult OrderPut([FromBody] Orders orders)
        {
            try
            {
                _orderDal.Update(orders);

                //return StatusCode(StatusCodes.Status200OK);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }


        [HttpDelete("DeleteOrder/{id?}")]
        public IActionResult DeleteOrder([FromBody] int orderId)
        {
            try
            {
                _orderDal.Delete(new Orders { Idorder = orderId });

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }




        [HttpGet("GetOrderModelOrderBy")]
        public IActionResult GetOrderModelOrderBy()
        {


            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;

            try
            {
                return Ok(_orderDal.GetOrderwithDetailts().OrderBy(O=>O.CustomerName));


            }
            catch (Exception)
            {


            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
