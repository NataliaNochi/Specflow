@create_users
Funcionalidade: Cadastrar Usuario
	Com a finalidade de cadastrar usuários
	Como administrador do sistema
	O formulário de usuário deve ser preenchido 

Contexto: Possuir acesso ao sistema
    Dado o login no sistema
   
@create_user_success
Cenário: Cadastro de usuário com sucesso
	E o acesso ao cadastro de usuários
	Quando os dados do usuário preenchidos são salvos
	| Titulo | Nome  | Genero | 
	| Mr.    | Maria | Female | 
	Então a o pop-up com a mensagem de cadastro com sucesso deve ser exibida
