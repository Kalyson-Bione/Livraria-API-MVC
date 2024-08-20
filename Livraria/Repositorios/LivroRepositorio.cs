using Livraria.Data;
using Livraria.Models;
using Livraria.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Repositorios
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly LivroDBContext _dbContext;
        public LivroRepositorio(LivroDBContext livroDBContext)
        {
            _dbContext = livroDBContext;
        }
        public async Task<LivroModel> BuscarPorId(int id)
        {
            return await _dbContext.Livros.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LivroModel>> BuscarTodosLivros()
        {
            return await _dbContext.Livros.ToListAsync();
        }

        public async Task<LivroModel> Adicionar(LivroModel livro)
        {
           await _dbContext.Livros.AddAsync(livro);
           await _dbContext.SaveChangesAsync();

            return livro;
        }
        public async Task<LivroModel> Atualizar(LivroModel livro, int id)
        {
            LivroModel livroPorId = await BuscarPorId(id);
            if (livroPorId == null)
            {
                throw new Exception($"Livro {id} não foi encontrado no banco de dados.");
            }
            livroPorId.Nome = livro.Nome;
            livroPorId.Autor = livro.Autor;
            livroPorId.Descricao = livro.Descricao;

            _dbContext.Livros.Update(livroPorId);
            await _dbContext.SaveChangesAsync();
            return livroPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            LivroModel livroPorId = await BuscarPorId(id);
            if (livroPorId == null)
            {
                throw new Exception($"Livro {id} não foi encontrado no banco de dados.");
            }
            _dbContext.Livros.Remove(livroPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
