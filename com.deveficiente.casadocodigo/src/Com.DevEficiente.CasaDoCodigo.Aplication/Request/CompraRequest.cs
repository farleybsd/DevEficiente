namespace Com.DevEficiente.CasaDoCodigo.Aplication.Request
{
    public class CompraRequest
    {
        [Required(ErrorMessage = "E-mail Obrigatorio")]
        [EmailAddress(ErrorMessage = "O email tem que ter formato válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Nome Obrigatorio")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Sobrenome Obrigatorio")]
        public string sobrenome { get; set; }

        [Required(ErrorMessage = "Documento Obrigatorio")]
        public string documento { get; set; }

        [Required(ErrorMessage = "Endereco Obrigatorio")]
        public string endereco { get; set; }

        [Required(ErrorMessage = "Complemento Obrigatorio")]
        public string complemento { get; set; }

        [Required(ErrorMessage = "Cidade Obrigatorio")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "Pais Obrigatorio")]
        public string pais { get; set; }

        [Required(ErrorMessage = "Estado Obrigatorio")]
        public string estado { get; set; }

        [Required(ErrorMessage = "Telefone Obrigatorio")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "Cep Obrigatorio")]
        public string cep { get; set; }

        public CompraSaveCommand RequestToCommand(CompraRequest compraRequest)
        {
            return new CompraSaveCommand(compraRequest.nome,
                compraRequest.sobrenome,
                compraRequest.documento,
                compraRequest.endereco,
                compraRequest.complemento,
                compraRequest.cidade,
                compraRequest.pais,
                compraRequest.estado,
                compraRequest.telefone,
                compraRequest.cep,
                compraRequest.Email);
        }
    }
}