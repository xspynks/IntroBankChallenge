/*
Criar um console app para movimentações financeiras
Criar Clientes Pessoa Física e Jurídica
Criar uma lista de movimentações para cada Cliente
Descontar taxa de R$2,00 para movimentação de PJ e R$1,00 para PF

Dicas:
--> Utilizar herança, encapsulamento e polimorfismo
--> Se atentar a caracter maiusculo e minusculo na string
--> Não se esqueça de adicionar o string
--> Console.ReadLine para receber do usuário
*/

using IntroBankChallenge;

List<Client> Clients = new List<Client>();
ConsultClient();

void ConsultClient()
{
    Console.WriteLine("Hello! Welcome to the Intro Bank!");
    Console.WriteLine("Type your code:");
    string code = Console.ReadLine();
    Client client = null;
    
    foreach (Client cli in Clients)
    {
        if (cli.Code == code)
        {
            client = cli;
        }
    }

    if (client == null)
    {
        Console.WriteLine("Client not found!");
        Console.WriteLine("Do you want to create a new client? (Y/N)");
        string registerClient = Console.ReadLine();
        if (registerClient == "Y")
        {
            Console.WriteLine("Type your code:");
            string codeNewClient = Console.ReadLine();
            Console.WriteLine("Type your name:");
            string nameNewClient = Console.ReadLine();
            Console.WriteLine("Are you a physical or legal person? (P/L)");
            string typeNewClient = Console.ReadLine();
            if (typeNewClient == "P")
                client = new PhysicalPerson(codeNewClient, nameNewClient);
            else
                client = new LegalPerson(codeNewClient, nameNewClient);
            Clients.Add(client);
            ShowMenu(client);
        }
        else
            Console.WriteLine("Ops! Something went wrong. Lets try again!");
        ConsultClient();
    }
}

void ShowMenu(Client client)
{
    Console.WriteLine($"Hello, {client.Name}");
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("1 - Balance");
    Console.WriteLine("2 - Withdraw");
    Console.WriteLine("3 - Deposit");
    
    string menuOption = Console.ReadLine();

    switch (menuOption)
    {
        case "1":
            ShowBalance(client);
            break;
        case "2":
            MakeWithdraw(client);
            break;
        case "3":
            MakeDeposit(client);
            break;
        default: Console.WriteLine("Type a valid answer: ");
            ShowMenu(client);
            break;
    }
}

void ShowBalance(Client client)
{
    Console.WriteLine("------- BALANCE -------");
    
    foreach (CashTransfer transfer in client.CashTransfers)
    {
        Console.WriteLine($"Type: {transfer.Type}");
        Console.WriteLine($"Amount: {transfer.Amount}");
    }
    
    Console.WriteLine("------- END BALANCE -------");   
    
    Console.WriteLine("Do you want to do another operation? (Y/N)");
    string anotherOperation = Console.ReadLine();
    if (anotherOperation == "Y")
        ShowMenu(client);
    else
        Console.WriteLine("Do you want to consult another client? (Y/N)");
    string consultClient = Console.ReadLine();
    if (consultClient == "Y")
        ConsultClient();
    else
        Console.WriteLine("Thank you for using our services!");
}

void MakeWithdraw(Client client)
{
    Console.WriteLine("Type the amount you want to withdraw:");
    string amount = Console.ReadLine();
    client.MakeWithdraw(Convert.ToDecimal(amount));
    Console.WriteLine("Do you want to do another operation? (Y/N)");
    string anotherOperation = Console.ReadLine();
    if (anotherOperation == "Y")
        ShowMenu(client);
    else
        Console.WriteLine("Thank you for using our services!");
}

void MakeDeposit(Client client)
{
    Console.WriteLine("Type the amount you want to deposit:");
    string amount = Console.ReadLine();
    client.MakeDeposit(Convert.ToDecimal(amount));
    Console.WriteLine("Do you want to do another operation? (Y/N)");
    string anotherOperation = Console.ReadLine();
    if (anotherOperation == "Y")
        ShowMenu(client);
    else
        Console.WriteLine("Thank you for using our services!");
}
