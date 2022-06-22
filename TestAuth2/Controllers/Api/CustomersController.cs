using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using VidlyTest.Models;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

[System.Web.Http.Route("api/customers")]
// [Route("api/[controller]")]
public class CustomersController : ApiController
{
    private Context _context;
    public CustomersController()
    {
        _context = new Context();
    }

    // GET /api/customers
    [System.Web.Http.HttpGet]
    public IEnumerable<CustomerDto> GetCustomers()
    {
        return _context.Customers
            .Include(c => c.MembershipType)
            .ToList()
            .Select(Mapper.Map<Customer, CustomerDto>);
    }
    
    // GET /api/customers/1
    [System.Web.Http.HttpGet]
    [System.Web.Http.Route("api/customers/{id}")]
    public IHttpActionResult GetCustomer(int id)
    {
        var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

        if (customer == null)
            return NotFound();
            
        return Ok(Mapper.Map<Customer, CustomerDto>(customer));
    }
    
    // POST /api/customers     
    [System.Web.Http.HttpPost]
    [System.Web.Http.Route("api/customers/{id}")]
    public IHttpActionResult CreateCustomer(CustomerDto customerDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
        _context.Customers.Add(customer);
        _context.SaveChanges();
        customerDto.Id = customer.Id;

        return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
    }
    
    // PUT /api/customer/1
    [System.Web.Http.HttpPut]
    [System.Web.Http.Route("api/customers/{id}")]
    public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

        if (customerInDb == null) 
            throw new HttpResponseException(HttpStatusCode.NotFound);

        Mapper.Map(customerDto, customerInDb);
        _context.SaveChanges();
        return Ok();
    }
    
    [System.Web.Http.HttpDelete]
    [System.Web.Http.Route("api/customers/{id}")]
    public void DeleteCustomer(int id)
    {
        var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

        if (customerInDb == null) 
            throw new HttpResponseException(HttpStatusCode.NotFound);

        _context.Customers.Remove(customerInDb);
        _context.SaveChanges();
    }
}


