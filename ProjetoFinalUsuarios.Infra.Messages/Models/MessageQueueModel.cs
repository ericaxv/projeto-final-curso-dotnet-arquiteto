﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Infra.Messages.Models
{
    /// <summary>
    /// Classe modelo para as mensagens que serão escritas na fila.
    /// </summary>
    public class MessageQueueModel
    {
        /// <summary>
        /// Identificador da mensagem na fila
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Conteudo da mensagem na fila
        /// </summary>
        public string? Conteudo { get; set; }
        /// <summary>
        /// Data e hora de escrita da mensagem na fila
        /// </summary>
        public DateTime? DataHoraCriacao { get; set; } = DateTime.Now;

        public TipoMensagem Tipo { get; set; }
    }

    /// <summary>
    /// Tipo da mensagem gravada na fila
    /// </summary>
    public enum TipoMensagem
    {
        CONFIRMACAO_DE_CADASTRO = 1,
        RECUPERACAO_DE_SENHA = 2
    }
}
