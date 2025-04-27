using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace tpmodul10_103022330152
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> _mahasiswas = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Aslam Rizky Fadillah", Nim = "103022330152" },
            new Mahasiswa { Nama = "Haikal", Nim = "103022300106" },
            new Mahasiswa { Nama = "Devon", Nim = "103022300085" },
            new Mahasiswa { Nama = "Subhan", Nim = "103022300081" },
            new Mahasiswa { Nama = "Angga", Nim = "103022300143 " },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> Get()
        {
            return Ok(_mahasiswas);
        }

        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> Get(int index)
        {
            if (index < 0 || index >= _mahasiswas.Count)
            {
                return NotFound("Mahasiswa not found");
            }

            return Ok(_mahasiswas[index]);
        }

        [HttpPost]
        public ActionResult<Mahasiswa> Post(Mahasiswa mahasiswa)
        {
            _mahasiswas.Add(mahasiswa);
            return CreatedAtAction(nameof(Get), new { index = _mahasiswas.Count - 1 }, mahasiswa);
        }

        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= _mahasiswas.Count)
            {
                return NotFound("Mahasiswa not found");
            }

            _mahasiswas.RemoveAt(index);
            return NoContent();
        }
    }
}
