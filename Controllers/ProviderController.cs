using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NDISBookingApi.DTOs.Provider;
using NDISBookingApi.Services.ProviderService;

namespace NDISBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;
        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        /// <summary>
        /// Get all providers.
        /// </summary>
        /// <returns>A list of all providers.</returns>
        /// <response code="200">Providers retrieved successfully.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ProviderResponseDto>>> GetAllProviders()
        {
            var providers = await _providerService.GetAllProviders();
            return Ok(providers);
        }

        /// <summary>
        /// Get a provider by ID.
        /// </summary>
        /// <param name="id">The ID of the provider.</param>
        /// <returns>The provider details.</returns>
        /// <response code="200">Provider retrieved successfully.</response>
        /// <response code="404">Provider not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProviderResponseDto>> GetProviderById(int id)
        {
            var provider = await _providerService.GetProviderById(id);
            return Ok(provider);
        }

        /// <summary>
        /// Create a new providerx.
        /// </summary>
        /// <param name="createProviderRequestDto">The provider data to create.</param>
        /// <returns>The newly created provider.</returns>
        /// <response code="201">Provider created successfully.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="404">Related user not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProviderResponseDto>> CreateProvider(CreateProviderRequestDto createProviderRequestDto)
        {
            var createdProvider = await _providerService.CreateProvider(createProviderRequestDto);
            return CreatedAtAction(nameof(GetProviderById), new { id = createdProvider.Id }, createdProvider);
        }

        /// <summary>
        /// Update an existing provider.
        /// </summary>
        /// <param name="id">The ID of the provider to update.</param>
        /// <param name="updateProviderRequestDto">The updated provider data.</param>
        /// <response code="204">Provider updated successfully.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="404">Provider or related user not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProvider(int id, UpdateProviderRequestDto updateProviderRequestDto)
        {
            await _providerService.UpdateProvider(id, updateProviderRequestDto);
            return NoContent();
        }

        /// <summary>
        /// Delete a provider by ID.
        /// </summary>
        /// <param name="id">The ID of the provider to delete.</param>
        /// <response code="204">Provider deleted successfully.</response>
        /// <response code="404">Provider not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProvider(int id)
        {
            await _providerService.DeleteProvider(id);
            return NoContent();
        }
    }
}
