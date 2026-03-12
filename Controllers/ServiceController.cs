using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NDISBookingApi.DTOs.Service;
using NDISBookingApi.Services.ServiceM;

namespace NDISBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceMService _serviceMService;

        public ServiceController(IServiceMService serviceMService)
        {
            _serviceMService = serviceMService;
        }

        /// <summary>
        /// Get all services.
        /// </summary>
        /// <returns>A list of all services.</returns>
        /// <response code="200">Services retrieved successfully.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ServiceResponseDto>>> GetAllServices()
        {
            var services = await _serviceMService.GetAllServices();
            return Ok(services);
        }

        /// <summary>
        /// Get a service by ID.
        /// </summary>
        /// <param name="id">The ID of the service.</param>
        /// <returns>The service details.</returns>
        /// <response code="200">Service retrieved successfully.</response>
        /// <response code="404">Service not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceResponseDto>> GetServiceById(int id)
        {
            var service = await _serviceMService.GetServiceById(id);
            return Ok(service);
        }

        /// <summary>
        /// Delete a service by ID.
        /// </summary>
        /// <param name="id">The ID of the service to delete.</param>
        /// <response code="204">Service deleted successfully.</response>
        /// <response code="404">Service not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceMService.DeleteService(id);
            return NoContent();
        }

        /// <summary>
        /// Update an existing service.
        /// </summary>
        /// <param name="id">The ID of the service to update.</param>
        /// <param name="updateServiceRequestDto">The updated service data.</param>
        /// <response code="204">Service updated successfully.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="404">Service not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateService(int id, [FromBody] UpdateServiceRequestDto updateServiceRequestDto)
        {
            await _serviceMService.UpdateService(id, updateServiceRequestDto);
            return NoContent();
        }

        /// <summary>
        /// Create a new service.
        /// </summary>
        /// <param name="createServiceRequestDto">The service data to create.</param>
        /// <returns>The newly created service.</returns>
        /// <response code="201">Service created successfully.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceResponseDto>> CreateService([FromBody] CreateServiceRequestDto createServiceRequestDto)
        {
            var createdService = await _serviceMService.CreateService(createServiceRequestDto);
            return CreatedAtAction(nameof(GetServiceById), new { id = createdService.Id }, createdService);
        }
    }
}
