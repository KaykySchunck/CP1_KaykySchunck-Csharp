using System;

class Program
{
    // Arrays fixos para armazenar os produtos, preços e quantidades no pedido
    static string[] produtos = { "Misto-Quente", "Soda Italiana", "Sunday Festa" };
    static double[] precos = { 15.00, 5.00, 7.00 };
    static int[] quantidades = { 0, 0, 0 }; // Inicializa com 0 unidades de cada produto

    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            ExibirMenu();
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ListarProdutos();
                    break;
                case "2":
                    AdicionarProdutoAoPedido();
                    break;
                case "3":
                    RemoverProdutoDoPedido();
                    break;
                case "4":
                    VisualizarPedido();
                    break;
                case "5":
                    FinalizarPedido();
                    continuar = false; // Encerra o programa
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            if (continuar)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static void ExibirMenu()
    {
        Console.WriteLine("==========Lanchonete do Kayky================");
        Console.WriteLine("1 - Listar produtos disponíveis");
        Console.WriteLine("2 - Adicionar produto ao pedido");
        Console.WriteLine("3 - Remover produto do pedido");
        Console.WriteLine("4 - Visualizar pedido atual");
        Console.WriteLine("5 - Finalizar pedido e sair");
        Console.Write("Escolha uma opção: ");
    }

    static void ListarProdutos()
    {
        Console.WriteLine("\nProdutos Disponíveis:");
        for (int i = 0; i < produtos.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {produtos[i]} - R$ {precos[i]:F2}");
        }
    }

    static void AdicionarProdutoAoPedido()
    {
        Console.WriteLine("\nInforme o código do produto que deseja adicionar:");
        ListarProdutos();
        int codigoProduto = int.Parse(Console.ReadLine()) - 1; // Subtrai 1 para ajustar o índice

        if (codigoProduto >= 0 && codigoProduto < produtos.Length)
        {
            Console.WriteLine($"Quantos {produtos[codigoProduto]} deseja adicionar?");
            int quantidade = int.Parse(Console.ReadLine());

            if (quantidade > 0)
            {
                quantidades[codigoProduto] += quantidade;
                Console.WriteLine($"{quantidade} {produtos[codigoProduto]} adicionado(s) ao pedido.");
            }
            else
            {
                Console.WriteLine("Quantidade inválida.");
            }
        }
        else
        {
            Console.WriteLine("Produto inválido.");
        }
    }

    static void RemoverProdutoDoPedido()
    {
        Console.WriteLine("\nInforme o código do produto que deseja remover:");
        ListarProdutos();
        int codigoProduto = int.Parse(Console.ReadLine()) - 1;

        if (codigoProduto >= 0 && codigoProduto < produtos.Length)
        {
            Console.WriteLine($"Quantos {produtos[codigoProduto]} deseja remover?");
            int quantidade = int.Parse(Console.ReadLine());

            if (quantidade > 0 && quantidades[codigoProduto] >= quantidade)
            {
                quantidades[codigoProduto] -= quantidade;
                Console.WriteLine($"{quantidade} {produtos[codigoProduto]} removido(s) do pedido.");
            }
            else
            {
                Console.WriteLine("Quantidade inválida ou não há produtos suficientes no pedido.");
            }
        }
        else
        {
            Console.WriteLine("Produto inválido.");
        }
    }

    static void VisualizarPedido()
    {
        Console.WriteLine("\nSeu pedido atual:");
        double valorTotal = 0;
        int totalItens = 0;

        for (int i = 0; i < produtos.Length; i++)
        {
            if (quantidades[i] > 0)
            {
                Console.WriteLine($"{produtos[i]} - {quantidades[i]} unidade(s) - R$ {precos[i]:F2} cada");
                valorTotal += precos[i] * quantidades[i];
                totalItens += quantidades[i];
            }
        }

        Console.WriteLine($"Total de itens: {totalItens}");
        Console.WriteLine($"Valor total do pedido: R$ {valorTotal:F2}");
    }

    static void FinalizarPedido()
    {
        double valorTotal = 0;
        int totalItens = 0;

        // Calcula o total de itens e o valor total do pedido
        for (int i = 0; i < produtos.Length; i++)
        {
            valorTotal += precos[i] * quantidades[i];
            totalItens += quantidades[i];
        }

        double desconto = 0;

        // Aplica desconto de 10% se o valor total for maior que R$ 100,00
        if (valorTotal > 100)
        {
            desconto = valorTotal * 0.10;
        }

        double valorFinal = valorTotal - desconto;

        // Exibe o resumo final do pedido
        Console.WriteLine("\nResumo do Pedido:");
        Console.WriteLine($"Total de itens: {totalItens}");
        Console.WriteLine($"Valor bruto: R$ {valorTotal:F2}");
        if (desconto > 0)
        {
            Console.WriteLine($"Desconto de 10% aplicado: -R$ {desconto:F2}");
        }
        Console.WriteLine($"Valor final a pagar: R$ {valorFinal:F2}");
    }
}
