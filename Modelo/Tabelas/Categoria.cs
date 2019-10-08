﻿using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Modelo.Tabelas
{
    public class Categoria
    {
        [DisplayName("Id")]
        public long CategoriaId { get; set; }

        [StringLength(100, ErrorMessage = "O nome da categoria precisa ter no minimo 3 caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}