Public Module EntryPoint
    Public Interface IChatPlugin
        Function GetResponse(ByVal message As String) As String
    End Interface
    Public Class Chatbot
        Private plugins As List(Of IChatPlugin)


        Public Sub New()
            plugins = New List(Of IChatPlugin)()
        End Sub

        Public Sub RegisterPlugin(ByVal plugin As IChatPlugin)
            plugins.Add(plugin)
        End Sub

        Public Function GetResponse(ByVal message As String) As String

            'RespondVia Plug-ins
            For Each plugin In plugins
                Dim response = plugin.GetResponse(message)

            Next

            Return "I'm sorry, I don't have a response for that."
        End Function
    End Class
    Public Sub main(args As String())
        ' Create an instance of the ChatInterface
        Dim chatbot As New Chatbot()
        '  TestRun(chatbot)
        ' Simulate user interaction with the chatbot
        While True
            Console.WriteLine("User: ")
            Dim Userinput As String = Console.ReadLine()

            ' Exit the loop if the user enters "quit"
            If Userinput.ToLower() = "quit" Then
                Exit While
            End If

            ' Get the chatbot's response
            Dim response As String = chatbot.GetResponse(Userinput)

            ' Display the chatbot's response
            Console.WriteLine("Chatbot: " + response)
            Console.WriteLine()
        End While

    End Sub
    ''' <summary>
    ''' tester
    ''' </summary>
    ''' <param name="bot"></param>
    Public Sub TestRun(ByRef bot As Chatbot)
        ' User inputs(Auto Run)
        Dim userInputs As List(Of String) = New List(Of String)()
        userInputs.Add("Hello!")
        userInputs.Add("How are you?")
        userInputs.Add("What's the weather like today?")
        userInputs.Add("What is the meaning of life?")
        userInputs.Add("Goodbye!")

        ' Chat loop
        For Each userInput In userInputs
            Dim response As String = bot.GetResponse(userInput)
            Console.WriteLine("User: " & userInput)
            Console.WriteLine("ChatBot: " & response)
            Console.WriteLine()
        Next
    End Sub

    Public Sub GetPlugins(ByRef Bot As Chatbot)
        '--------------------------------
        'RegisterPlugins for use with bot
        '--------------------------------
        '  Bot.RegisterPlugin(New MainPlugin())
    End Sub
End Module
