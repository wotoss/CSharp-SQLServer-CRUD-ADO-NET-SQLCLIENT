# 📌 CSharp-SQLServer-CRUD-ADO-NET-SQLCLIENT

Projeto de exemplo em **C#** utilizando **ADO.NET** com a biblioteca `Microsoft.Data.SqlClient` para realizar operações **CRUD** (Create, Read, Update, Delete) em um banco de dados **SQL Server**.

## 🚀 Tecnologias utilizadas
- **C# (.NET)**
- **SQL Server**
- **ADO.NET**
- **Microsoft.Data.SqlClient**

---

## 📂 Estrutura do projeto


---

## 🔹 Funcionalidades
- **Listar artistas** (Read)
- **Adicionar novo artista** (Create)
- **Atualizar artista existente** (Update)
- **Excluir artista** (Delete)

---

## 🗄 Banco de Dados
O projeto utiliza a tabela **Artistas** no SQL Server com a seguinte estrutura:

```sql
CREATE TABLE Artistas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(200) NOT NULL,
    FotoPerfil NVARCHAR(500),
    Bio NVARCHAR(MAX)
);

⚙️ Como configurar e executar
1️- Clonar o repositório
git clone https://github.com/SEU-USUARIO/CSharp-SQLServer-CRUD-ADO-NET-SQLCLIENT.git

2️- Configurar a conexão com o banco

private const string ConnectionString = "Data Source=SEU_SERVIDOR;Initial Catalog=SUA_BASE;Integrated Security=True";

3️- Criar a tabela no SQL Server

Execute o script SQL informado acima para criar a tabela Artistas.

4️- Executar o projeto

dotnet build
dotnet run

📜 Licença

Este projeto é livre para uso e modificação.
Sinta-se à vontade para clonar, estudar e adaptar para suas necessidades.


---

Se quiser, eu já posso criar **um `.gitignore` otimizado para .NET** para colocar junto desse README e deixar o repositório limpo e profissional.  
Quer que eu faça isso também?
