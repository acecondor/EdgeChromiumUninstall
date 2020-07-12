Imports System
Imports System.IO

Module modMain

    Dim _EdgePath As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Microsoft\Edge\Application\"


    Sub Main()
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("EdgeChromiumUninstall v." & My.Application.Info.Version.ToString)
        Console.WriteLine(My.Application.Info.Copyright) 'copyright
        Console.WriteLine()
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("Il programma è un software libero; potete redistribuirlo e/o secondo i termini della come pubblicato ")
        Console.WriteLine("dalla Free Software Foundation; sia la versione 3, sia (a vostra scelta) ogni versione successiva.")
        Console.WriteLine()
        Console.WriteLine("Questo programma è distribuito nella speranza che sia utile ma SENZA ALCUNA GARANZIA senza")
        Console.WriteLine("anche l'implicita garanzia di POTER ESSERE VENDUTO o di IDONEITA' A UN PROPOSITO PARTICOLARE.")
        Console.WriteLine("Vedere la GNU General Public License per ulteriori dettagli.")
        Console.WriteLine("https://www.gnu.org/licenses/gpl-3.0.txt")
        Console.WriteLine()
        Console.ForegroundColor = ConsoleColor.White

        Try
            If Directory.Exists(_EdgePath) Then 'verifico esista cartella

                For Each Dir As String In Directory.GetDirectories(_EdgePath, "*.*") 'recupero elenco cartelle 

                    Dim _version As String = New DirectoryInfo(Dir).Name 'recupero nome ultima cartella percorso

                    If ReturnOnlyNumeric(_version) <> Nothing Then 'elaboro solo se nome cartella numerico

                        Console.WriteLine("Disinstallare la versione " & _version & "?")
                        Console.WriteLine("Premi S per disinstallare, altro tasto per uscire")

                        If Console.ReadKey.KeyChar.ToString.ToUpper = "S" Then
                            Console.WriteLine()
                            Process.Start(_EdgePath & _version & "\installer\setup.exe", "--uninstall --system-level --verbose-logging --force-uninstall")
                        End If
                    End If
                Next
            Else

                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Non esiste la cartella " & _EdgePath)
                Console.ForegroundColor = ConsoleColor.White

            End If

        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine(Err.Description)
            Console.ForegroundColor = ConsoleColor.White
        End Try
        Console.WriteLine("Premi un tasto per uscire")
        Console.ReadKey()
    End Sub

    Private Function ReturnOnlyNumeric(ByVal _text As String)
        Try
            If IsNumeric(_text) Then
                Return _text
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine(Err.Description)
            Console.ForegroundColor = ConsoleColor.White
            Return Nothing
        End Try
    End Function

End Module
