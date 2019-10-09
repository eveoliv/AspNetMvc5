﻿using Modelo.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Cadastros
{
    public class Produto
    {
        [DisplayName("Id")]
        public long? ProdutoId { get; set; }

        [StringLength(100, ErrorMessage = "O nome do produto precisa ter no minimo 3 caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Nome { get; set; }

        [DisplayName("Data Cadastro")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Informe a data de cadastro do produto")]
        public DateTime? DataCadastro { get; set; }

        [DisplayName("Categoria")]
        public long? CategoriaId { get; set; }

        [DisplayName("Fabricante")]
        public long? FabricanteId { get; set; }

        public Categoria Categoria { get; set; }
        public Fabricante Fabricante { get; set; }

    }
}