using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
		ICategoriaDao _daoCategoria;
		ILeilaoDao _daoLeilao;

		public LeilaoApiController(ICategoriaDao daoCategoria, ILeilaoDao daoLeilao)
        {
			_daoCategoria = daoCategoria;
            _daoLeilao = daoLeilao;
		}

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leiloes = _daoLeilao.BuscarLeiloes();
            return Ok(leiloes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = _daoLeilao.BuscarPorId(id);
            if (leilao == null)
            {
                return NotFound();
            }
            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
			_daoLeilao.Add(leilao);
			return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
			_daoLeilao.Update(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = _daoLeilao.BuscarPorId(id);
            if (leilao == null)
            {
                return NotFound();
            }
			_daoLeilao.Remove(leilao);
            return NoContent();
        }


    }
}
