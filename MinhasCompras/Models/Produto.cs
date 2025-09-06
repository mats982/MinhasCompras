using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MinhasCompras.Models
{
    public class Produto
    {
        string _descricao;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { 
            get => _descricao;
            set 
            {
                if(value == null) 
                {
                    throw new Exception("Por favor, preencha a descrição");
                }

                _descricao = value;
            }
        }

        double _quantidade;
        public double Quantidade {
            get => _quantidade;
            set 
            {
                if (value == 0)
                {
                    throw new Exception("Por favor, preencha a quantidade");
                }

                _quantidade = value;
            }
        }

        double _preco;
        public double Preco { 
            get => _preco;
            set 
            {
                if (value == 0)
                {
                    throw new Exception("Por favor, preencha o preço");
                }

                _preco = value;
            } 
        }
        public double Total { get => Quantidade *  Preco; }
    }

}
