Este projeto foi desenvolvido utilizando .NET 5 e PostgreSQL10 com EntityFramework. 

O banco de dados foi gerado através do console nuget, usando code-first.
Foram criadas 3 constraints no banco como regra, os campos e-mail, senha e documento não podem ser nulos.

1.Criar o servidor no banco local no cliente pgAdmin 4, utilizando a connection string do projeto, que está na página appsetings.json. 
2.Abrir o console do nuget (com o banco já configurado e aberto) e rodar o comando "update-database". 

O banco será gerado automáticamente na conexão estabelecida. 

Este projeto foi desenvolvido em cerca de 12 horas.
