using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BelezaNaWeb.API.Extensions;
using BelezaNaWeb.Application.DTOs;
using BelezaNaWeb.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BelezaNaWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService iProdutoService;
        private readonly ILogger<ProdutoController> iLogger;
        public ProdutoController(IProdutoService iProdutoService, ILogger<ProdutoController> iLogger)
        {
            this.iProdutoService = iProdutoService;
            this.iLogger = iLogger;
        }

        #region async Task<ActionResult<ResponseDTO<ProdutoDTO>>> ObterProduto([FromRoute] string sku)
        [HttpGet]
        [Route("ObterProduto/{sku}")]
        public async Task<ActionResult<ResponseDTO<ProdutoDTO>>> ObterProduto([FromRoute] string sku)
        {
            try
            {
                ProdutoDTO response = await iProdutoService.ObterProduto(new ProdutoDTO { Sku = sku });
                if (response == null)
                    return NotFound(new ResponseDTO<ProdutoDTO>(StatusCodes.Status404NotFound, "Warning", null, "Produto não localizado!"));

                return Ok(new ResponseDTO<ProdutoDTO>(StatusCodes.Status200OK, "OK", response, null));
            }
            catch (Exception ex)
            {
                iLogger.LogError(ex.Message);
                return BadRequest(new ResponseDTO<ProdutoDTO>(StatusCodes.Status500InternalServerError, "Error", null, ex.Message));
            }
        } 
        #endregion

        #region async Task<ActionResult<ResponseDTO<ProdutoDTO>>> CadastrarProdutos([FromBody] ProdutoDTO produtoDTO)
        /// <summary>
        /// Método para cadastro de novos produtos.
        /// </summary>
        /// <param name="produtoDTO">Produto a ser cadastrado</param>
        /// <returns>ResponseDTO</returns>
        [HttpPost]
        [Route("CadastrarProdutos")]
        public async Task<ActionResult<ResponseDTO<ProdutoDTO>>> CadastrarProdutos([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResponseDTO<ProdutoDTO>(StatusCodes.Status400BadRequest, "Warning", null, ModelStateExtensions.ModelStateInvalid(ModelState)));

                ProdutoDTO response = await iProdutoService.CadastrarProduto(produtoDTO);

                if (response == null) 
                    return BadRequest(new ResponseDTO<ProdutoDTO>(StatusCodes.Status404NotFound, "Warning", null, "Produto já consta cadastrado!"));

                return CreatedAtAction(nameof(CadastrarProdutos), new ResponseDTO<ProdutoDTO>(StatusCodes.Status201Created, "OK", response, null));
            }
            catch (Exception ex)
            {
                iLogger.LogError(ex.Message);
                return BadRequest(new ResponseDTO<ProdutoDTO>(StatusCodes.Status500InternalServerError, "Error", null, ex.Message));
            }
        }
        #endregion

        #region async Task<ActionResult<ResponseDTO<ProdutoDTO>>> AtualizarProduto([FromRoute] string sku, [FromBody] ProdutoDTO produtoDTO)
        /// <summary>
        /// Método utilizado para atualização de produtos
        /// </summary>
        /// <param name="sku">Sku do produto que deseja atualizar</param>
        /// <param name="produtoDTO">Produto que deseja atualizar</param>
        /// <returns>ResponseDTO</returns>
        [HttpPut]
        [Route("AtualizarProduto/{sku}")]
        public async Task<ActionResult<ResponseDTO<ProdutoDTO>>> AtualizarProduto([FromRoute] string sku, [FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResponseDTO<ProdutoDTO>(StatusCodes.Status400BadRequest, "Warning", null, ModelStateExtensions.ModelStateInvalid(ModelState)));

                if (produtoDTO.Sku != sku)
                    return NotFound(new ResponseDTO<ProdutoDTO>(StatusCodes.Status404NotFound, "Warning", null, "Os Sku's informados não são iguais!"));

                ProdutoDTO response = await iProdutoService.AtualizarProduto(produtoDTO);

                if (response == null)
                    return NotFound(new ResponseDTO<ProdutoDTO>(StatusCodes.Status404NotFound, "Warning", null, "Produto não localizado!"));

                return Ok(new ResponseDTO<ProdutoDTO>(StatusCodes.Status200OK, "OK", response, null));
            }
            catch (Exception ex)
            {
                iLogger.LogError(ex.Message);
                return BadRequest(new ResponseDTO<ProdutoDTO>(StatusCodes.Status500InternalServerError, "Error", null, ex.Message));
            }
        }
        #endregion

        #region async Task<ActionResult<ResponseDTO<ProdutoDTO>>> DeletarProduto([FromRoute] string sku, [FromBody] ProdutoDTO produtoDTO)
        /// <summary>
        /// Método utilizado para exclusão de produto
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="produtoDTO"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeletarProduto/{sku}")]
        public async Task<ActionResult<ResponseDTO<ProdutoDTO>>> DeletarProduto([FromRoute] string sku, [FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResponseDTO<ProdutoDTO>(StatusCodes.Status400BadRequest, "Warning", null, ModelStateExtensions.ModelStateInvalid(ModelState)));

                if (produtoDTO.Sku != sku)
                    return NotFound(new ResponseDTO<ProdutoDTO>(StatusCodes.Status404NotFound, "Warning", null, "Os Sku's informados não são iguais!"));

                ProdutoDTO response = await iProdutoService.DeletarProduto(produtoDTO);

                if (response == null)
                    return NotFound(new ResponseDTO<ProdutoDTO>(StatusCodes.Status404NotFound, "Warning", null, "Produto não localizado!"));

                return Ok(new ResponseDTO<ProdutoDTO>(StatusCodes.Status200OK, "OK", response, null));
            }
            catch (Exception ex)
            {
                iLogger.LogError(ex.Message);
                return BadRequest(new ResponseDTO<ProdutoDTO>(StatusCodes.Status500InternalServerError, "Error", null, ex.Message));
            }
        } 
        #endregion
    }
}
