﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Admin.Countries;
using Services.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace App.Controllers.Admin
{
    public class CountryController : BaseController
    {
        private readonly ICountryService _countryService;
        private readonly ILogger<CountryController> _logger;
        public CountryController(ICountryService countryService, ILogger<CountryController> logger)
        {
            _countryService = countryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            _logger.LogInformation("country get all is working");
            return Ok(await _countryService.GetAllAsync());
            //try
            //{
            //    _logger.LogInformation("country get all is working");
            //    return Ok(await _countryService.GetAllAsync());
            //}
            //catch (Exception ex)
            //{

            //  return   StatusCode(StatusCodes.Status500InternalServerError, new {message = ex.Message});
            //}
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CountryCreateDto request)
        {
            await _countryService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { response = "Data successfully Created" });

            //try
            //{
            //    await _countryService.CreateAsync(request);
            //    return CreatedAtAction(nameof(Create),new { response = "Data successfully Created"});
            //}
            //catch (Exception ex)
            //{

            //    return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            //}

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _countryService.GetByIdAsync(id));

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery][Required] int id)
        {
            await _countryService.DeleteAsync(id);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] CountryEditDto reuqest )
        {
            await _countryService.EditAsync(id, reuqest);

            return Ok();
        }

    }
}
