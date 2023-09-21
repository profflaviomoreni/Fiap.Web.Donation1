﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Fiap.Web.Donation1.Models
{

    [Table("Produto")]
    public class ProdutoModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        public bool Disponivel { get; set; }

        [StringLength(150)]
        public string Descricao { get; set; }

        [StringLength(200)]
        public string SugestaoTroca { get; set; } 
        
        public double Valor { get; set; }


        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime DataExpiracao { get; set; }


        //Foreing Key
        public int UsuarioId { get; set; }

        //Navigation Property
        [ForeignKey(nameof(UsuarioId))]
        public UsuarioModel Usuario { get; set; }



        //Foreign Key
        public int TipoProdutoId { get; set; }

        //Navigation Property
        //[ForeignKey("TipoProdutoId")]
        [ForeignKey(nameof(TipoProdutoId))]
        public TipoProdutoModel TipoProduto { get; set; }

    }
}
