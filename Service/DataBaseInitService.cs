using Model.Contexts;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    public interface IDataBaseInitService 
    {
        Task InitDataBase();
    }

    public class DataBaseInitService : IDataBaseInitService
    {


        private readonly TitanContext _ctx;

        public DataBaseInitService(TitanContext ctx)
        {
            _ctx = ctx;
        }


        public async Task InitDataBase()
        {
            _ctx.Database.EnsureCreated();

            var isDbFull = _ctx.OriginalTitans.Count();

            if (isDbFull != 9)
            {
                var lstOriginalTitans = new List<OriginalTitan>()
                {

                    new OriginalTitan()
                    {
                        Name = "Titã De Ataque",
                        Description = "O Titã de Ataque pode ver através das memórias de seus possuidores do passado e do futuro, e lutou pela liberdade ao longo das gerações.",
                        ImageUrl = "images/attack.png",
                    },

                    new OriginalTitan()
                    {
                        Name = "Titã Femea",
                        Description = "A Titã Fêmea possui a habilidade de atrair Titãs Puros com seus gritos e também endurecer seletivamente partes de sua pele.",
                        ImageUrl = "images/female.png",
                    },

                    new OriginalTitan()
                    {
                        Name = "Titã Colossal",
                        Description = "O Titã Colossal é notável pelo tamanho maciço e controle sobre o vapor emitido por seu corpo, e o controle do poder da explosão de sua transformação.",
                        ImageUrl = "images/colossal.png",
                    },

                    new OriginalTitan()
                    {
                        Name = "Titã Blindado",
                        Description = "O Titã Blindado possui placas de pele blindadas em todo o corpo, sua dureza é ipenetrável por lâminas ou simples canhões.",
                        ImageUrl = "images/blindado.png",
                    },

                    new OriginalTitan()
                    {
                        Name = "Titã Bestial",
                        Description = "O Titã Bestial, sob a posse de Zeke Yeager, possui sangue real, habilidade de controlar Titãs irracionais, além de transformar Eldianos comuns em titãs irracionais.",
                        ImageUrl = "images/bestial.png",
                    },

                    new OriginalTitan()
                    {
                        Name = "Titã Quadrúpede",
                        Description = "O Titã Quadrúpede destaca-se por ter uma forma quadrúpede e possuindo velocidade e resistência devastadoras.",
                        ImageUrl = "images/cart.png",
                    },

                    new OriginalTitan()
                    {
                        Name = "Titã Fundador",
                        Description = "O Titã Fundador é o primeiro de todos os Titãs. Seu Grito pode criar e controlar outros Titãs, modificar as memórias e composições corporais dos Súditos de Ymir.",
                        ImageUrl = "images/founding.png",
                    },

                    new OriginalTitan()
                    {
                        Name = "Titã Mandibula",
                        Description = "O Titã Mandíbula tem um conjunto poderoso de mandíbulas e garras que são capazes de rasgar quase tudo. É o Titã mais veloz de todos, graças ao seu pequeno tamanho.",
                        ImageUrl = "images/jaw.png",
                    },

                    new OriginalTitan()
                    {
                        Name = "Titã Mandibula",
                        Description = "O Titã Martelo de Guerra possui a habilidade de criar estruturas endurecidas, possuindo qualquer arma que queira criar desde besta e espinhos à um martelo",
                        ImageUrl = "images/warhammer.png",
                    },

                };

                foreach (var ett in lstOriginalTitans)
                {
                    await _ctx.OriginalTitans.AddAsync(ett);
                    await _ctx.SaveChangesAsync();
                }
            }
        }







    }
}
