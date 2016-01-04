Public Class Form1

    Dim Player1Name As String = "Cristi"
    Dim Player2Name As String = "Adi"
    Dim Player3Name As String = "Lus"
    Dim Player4Name As String = "Dan"
    Dim Player5Name As String = "Razvan"
    Dim Player6Name As String = "Doru"

    Dim ScorP1R1R1 As Integer
    Dim ScorP2R1R1 As Integer

    Dim cRound As Integer = 1
    Dim CurrentPlayer As String
    Dim row As Integer = 0

    Dim myBid As Integer
    Dim endBid As Integer

    'btnP1
    Private Sub btnP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP1.Click
        CurrentPlayer = Player1Name
        btnAddScore.Items.Add("Liciteaza " & Player1Name)
        btnP1.Enabled = False
    End Sub
    'btnP2
    Private Sub btnP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP2.Click
        CurrentPlayer = Player2Name
        btnAddScore.Items.Add("Liciteaza " & Player2Name)
        btnP2.Enabled = False
    End Sub
    'btnP3
    Private Sub btnP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP3.Click
        CurrentPlayer = Player3Name
        btnAddScore.Items.Add("Liciteaza " & Player3Name)
        btnP3.Enabled = False
    End Sub
    'btnP4
    Private Sub btnP4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP4.Click
        CurrentPlayer = Player4Name
        btnAddScore.Items.Add("Liciteaza " & Player4Name)
        btnP4.Enabled = False
    End Sub
    'btnP5
    Private Sub btnP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP5.Click
        CurrentPlayer = Player5Name
        btnAddScore.Items.Add("Liciteaza " & Player5Name)
        btnP5.Enabled = False
    End Sub
    'btnP6
    Private Sub btnP6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP6.Click
        CurrentPlayer = Player6Name
        btnAddScore.Items.Add("Liciteaza" & Player6Name)
        btnP6.Enabled = False
    End Sub

    'btn0
    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click
        myBid = 0
        btnAddScore.Items.Add(CurrentPlayer & " a licitat " & myBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(2).Value = myBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(4).Value = myBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(6).Value = myBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(8).Value = myBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(10).Value = myBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(12).Value = myBid
        End If
    End Sub
    'btn1
    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        myBid = 1
        btnAddScore.Items.Add(CurrentPlayer & " a licitat " & myBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(2).Value = myBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(4).Value = myBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(6).Value = myBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(8).Value = myBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(10).Value = myBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(12).Value = myBid
        End If
    End Sub
    'btn2
    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        myBid = 2
        btnAddScore.Items.Add(CurrentPlayer & " a licitat " & myBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(2).Value = myBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(4).Value = myBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(6).Value = myBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(8).Value = myBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(10).Value = myBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(12).Value = myBid
        End If
    End Sub
    'btn3
    Private Sub btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3.Click
        myBid = 3
        btnAddScore.Items.Add(CurrentPlayer & " a licitat " & myBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(2).Value = myBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(4).Value = myBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(6).Value = myBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(8).Value = myBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(10).Value = myBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(12).Value = myBid
        End If
    End Sub
    'btn4
    Private Sub btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn4.Click
        myBid = 4
        btnAddScore.Items.Add(CurrentPlayer & " a licitat " & myBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(2).Value = myBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(4).Value = myBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(6).Value = myBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(8).Value = myBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(10).Value = myBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(12).Value = myBid
        End If
    End Sub
    'btn5
    Private Sub btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn5.Click
        myBid = 5
        btnAddScore.Items.Add(CurrentPlayer & " a licitat " & myBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(2).Value = myBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(4).Value = myBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(6).Value = myBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(8).Value = myBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(10).Value = myBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(12).Value = myBid
        End If
    End Sub
    'btn6
    Private Sub btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn6.Click
        myBid = 6
        btnAddScore.Items.Add(CurrentPlayer & " a licitat " & myBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(2).Value = myBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(4).Value = myBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(6).Value = myBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(8).Value = myBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(10).Value = myBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(12).Value = myBid
        End If
    End Sub
    'btn7
    Private Sub btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn7.Click
        myBid = 7
        btnAddScore.Items.Add(CurrentPlayer & " a licitat " & myBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(2).Value = myBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(4).Value = myBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(6).Value = myBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(8).Value = myBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(10).Value = myBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(12).Value = myBid
        End If
    End Sub
    'btn8
    Private Sub btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn8.Click
        myBid = 8
        btnAddScore.Items.Add(CurrentPlayer & " a licitat " & myBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(2).Value = myBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(4).Value = myBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(6).Value = myBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(8).Value = myBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(10).Value = myBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(12).Value = myBid
        End If
    End Sub

    'btnEnd0
    Private Sub End0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles End0.Click
        endBid = 0
        btnAddScore.Items.Add(CurrentPlayer & " a facut " & endBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(13).Value = endBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(14).Value = endBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(15).Value = endBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(16).Value = endBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(17).Value = endBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(18).Value = endBid
        End If
    End Sub
    'btnEnd1
    Private Sub End1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles End1.Click
        endBid = 1
        btnAddScore.Items.Add(CurrentPlayer & " a facut " & endBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(13).Value = endBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(14).Value = endBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(15).Value = endBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(16).Value = endBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(17).Value = endBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(18).Value = endBid
        End If
    End Sub
    'btnEnd2
    Private Sub End2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles End2.Click
        endBid = 2
        btnAddScore.Items.Add(CurrentPlayer & " a facut " & endBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(13).Value = endBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(14).Value = endBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(15).Value = endBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(16).Value = endBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(17).Value = endBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(18).Value = endBid
        End If
    End Sub
    'btnEnd3
    Private Sub End3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles End3.Click
        endBid = 3
        btnAddScore.Items.Add(CurrentPlayer & " a facut " & endBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(13).Value = endBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(14).Value = endBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(15).Value = endBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(16).Value = endBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(17).Value = endBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(18).Value = endBid
        End If
    End Sub
    'btnEnd4
    Private Sub End4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles End4.Click
        endBid = 4
        btnAddScore.Items.Add(CurrentPlayer & " a facut " & endBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(13).Value = endBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(14).Value = endBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(15).Value = endBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(16).Value = endBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(17).Value = endBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(18).Value = endBid
        End If
    End Sub
    'btnEnd5
    Private Sub End5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles End5.Click
        endBid = 5
        btnAddScore.Items.Add(CurrentPlayer & " a facut " & endBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(13).Value = endBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(14).Value = endBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(15).Value = endBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(16).Value = endBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(17).Value = endBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(18).Value = endBid
        End If
    End Sub
    'btnEnd6
    Private Sub End6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles End6.Click
        endBid = 6
        btnAddScore.Items.Add(CurrentPlayer & " a facut " & endBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(13).Value = endBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(14).Value = endBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(15).Value = endBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(16).Value = endBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(17).Value = endBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(18).Value = endBid
        End If
    End Sub
    'btnEnd7
    Private Sub End7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles End7.Click
        endBid = 7
        btnAddScore.Items.Add(CurrentPlayer & " a facut " & endBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(13).Value = endBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(14).Value = endBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(15).Value = endBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(16).Value = endBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(17).Value = endBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(18).Value = endBid
        End If
    End Sub
    'btnEnd8
    Private Sub End8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles End8.Click
        endBid = 8
        btnAddScore.Items.Add(CurrentPlayer & " a facut " & endBid)

        If CurrentPlayer = Player1Name Then
            DataGridView1.Rows(row).Cells(13).Value = endBid
        ElseIf CurrentPlayer = Player2Name Then
            DataGridView1.Rows(row).Cells(14).Value = endBid
        ElseIf CurrentPlayer = Player3Name Then
            DataGridView1.Rows(row).Cells(15).Value = endBid
        ElseIf CurrentPlayer = Player4Name Then
            DataGridView1.Rows(row).Cells(16).Value = endBid
        ElseIf CurrentPlayer = Player5Name Then
            DataGridView1.Rows(row).Cells(17).Value = endBid
        ElseIf CurrentPlayer = Player6Name Then
            DataGridView1.Rows(row).Cells(18).Value = endBid
        End If
    End Sub

    'btnEndP1
    Private Sub EndP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndP1.Click
        CurrentPlayer = Player1Name
        btnAddScore.Items.Add("Cate a facut " & Player1Name & " ?")
        EndP1.Enabled = False
    End Sub
    'btnEndP2
    Private Sub EndP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndP2.Click
        CurrentPlayer = Player2Name
        btnAddScore.Items.Add("Cate a facut " & Player2Name & " ?")
        EndP2.Enabled = False
    End Sub
    'btnEndP3
    Private Sub EndP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndP3.Click
        CurrentPlayer = Player3Name
        btnAddScore.Items.Add("Cate a facut " & Player3Name & " ?")
        EndP3.Enabled = False
    End Sub
    'btnEndP4
    Private Sub EndP4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndP4.Click
        CurrentPlayer = Player4Name
        btnAddScore.Items.Add("Cate a facut " & Player4Name & " ?")
        EndP4.Enabled = False
    End Sub
    'btnEndP5
    Private Sub EndP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndP5.Click
        CurrentPlayer = Player5Name
        btnAddScore.Items.Add("Cate a facut " & Player5Name & " ?")
        EndP5.Enabled = False
    End Sub
    'btnEndP6
    Private Sub EndP6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndP6.Click
        CurrentPlayer = Player6Name
        btnAddScore.Items.Add("Cate a facut " & Player6Name & " ?")
        EndP6.Enabled = False
    End Sub

    'ScorP1R1
    Public Function ScorP1R1() As Integer
        Dim L1 As Integer = DataGridView1.Rows(row).Cells(2).Value
        Dim E1 As Integer = DataGridView1.Rows(row).Cells(13).Value
        Dim D1 As Integer = L1 - E1
        Dim T1 As Integer

        If D1 = 0 Then
            T1 = L1 + 5
        ElseIf D1 <> 0 Then
            T1 = -1
        End If

        'Dim Total As Integer = DataGridView1.Rows(row).Cells(1).Value

        Return T1
    End Function

    'ScorP2R1
    Public Function ScorP2R1() As Integer
        Dim L1 As Integer = DataGridView1.Rows(row).Cells(4).Value
        Dim E1 As Integer = DataGridView1.Rows(row).Cells(14).Value
        Dim D1 As Integer = L1 - E1
        Dim T1 As Integer

        If D1 = 0 Then
            T1 = L1 + 5
        ElseIf D1 <> 0 Then
            T1 = -1
        End If

        Return T1
    End Function
    'ScorP3R1
    Public Function ScorP3R1() As Integer
        Dim L1 As Integer = DataGridView1.Rows(row).Cells(6).Value
        Dim E1 As Integer = DataGridView1.Rows(row).Cells(15).Value
        Dim D1 As Integer = L1 - E1
        Dim T1 As Integer

        If D1 = 0 Then
            T1 = L1 + 5
        ElseIf D1 <> 0 Then
            T1 = -1
        End If

        Return T1
    End Function
    'ScorP4R1
    Public Function ScorP4R1() As Integer
        Dim L1 As Integer = DataGridView1.Rows(row).Cells(8).Value
        Dim E1 As Integer = DataGridView1.Rows(row).Cells(16).Value
        Dim D1 As Integer = L1 - E1
        Dim T1 As Integer

        If D1 = 0 Then
            T1 = L1 + 5
        ElseIf D1 <> 0 Then
            T1 = -1
        End If

        Return T1
    End Function
    'ScorP5R1
    Public Function ScorP5R1() As Integer
        Dim L1 As Integer = DataGridView1.Rows(row).Cells(8).Value
        Dim E1 As Integer = DataGridView1.Rows(row).Cells(17).Value
        Dim D1 As Integer = L1 - E1
        Dim T1 As Integer

        If D1 = 0 Then
            T1 = L1 + 5
        ElseIf D1 <> 0 Then
            T1 = -1
        End If

        Return T1
    End Function
    'ScorP6R1
    Public Function ScorP6R1() As Integer
        Dim L1 As Integer = DataGridView1.Rows(row).Cells(10).Value
        Dim E1 As Integer = DataGridView1.Rows(row).Cells(18).Value
        Dim D1 As Integer = L1 - E1
        Dim T1 As Integer

        If D1 = 0 Then
            T1 = L1 + 5
        ElseIf D1 <> 0 Then
            T1 = -1
        End If

        Return T1
    End Function

    'FormLoad
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        btnEndRoundScore.Enabled = False
        btnUpdScore.Enabled = False
        If row = 0 Then
            btn2.Enabled = False
            btn3.Enabled = False
            btn4.Enabled = False
            btn5.Enabled = False
            btn6.Enabled = False
            btn7.Enabled = False
            btn8.Enabled = False
            End2.Enabled = False
            End3.Enabled = False
            End4.Enabled = False
            End5.Enabled = False
            End6.Enabled = False
            End7.Enabled = False
            End8.Enabled = False
        End If
        Me.DataGridView1.Columns(1).HeaderText = Player1Name
        Me.DataGridView1.Columns(3).HeaderText = Player2Name
        Me.DataGridView1.Columns(5).HeaderText = Player3Name
        Me.DataGridView1.Columns(7).HeaderText = Player4Name
        Me.DataGridView1.Columns(9).HeaderText = Player5Name
        Me.DataGridView1.Columns(11).HeaderText = Player6Name
        btnP1.Text = Player1Name
        btnP2.Text = Player2Name
        btnP3.Text = Player3Name
        btnP4.Text = Player4Name
        btnP5.Text = Player5Name
        btnP6.Text = Player6Name
        EndP1.Text = Player1Name
        EndP2.Text = Player2Name
        EndP3.Text = Player3Name
        EndP4.Text = Player4Name
        EndP5.Text = Player5Name
        EndP6.Text = Player6Name
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
    End Sub

    'btnStartNextRound
    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartNextRound.Click
        DataGridView1.Rows.Insert(row, "1")
        btnStartNextRound.Enabled = False
        btnEndRoundScore.Enabled = True
        GroupBox1.Enabled = True
        GroupBox2.Enabled = False
        btnP1.Enabled = True
        btnP2.Enabled = True
        btnP3.Enabled = True
        btnP4.Enabled = True
        btnP5.Enabled = True
        btnP6.Enabled = True
        EndP1.Enabled = True
        EndP2.Enabled = True
        EndP3.Enabled = True
        EndP4.Enabled = True
        EndP5.Enabled = True
        EndP6.Enabled = True
    End Sub

    'btnEndRound
    Private Sub btnEndRoundScore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEndRoundScore.Click
        btnEndRoundScore.Enabled = False
        btnUpdScore.Enabled = True
        GroupBox2.Enabled = True
        GroupBox1.Enabled = False

    End Sub

    'btnUpdateScore
    Private Sub btnUpdScore_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdScore.Click
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
        btnStartNextRound.Enabled = True
        btnEndRoundScore.Enabled = False
        btnUpdScore.Enabled = False
        DataGridView1.Rows(row).Cells(1).Value = ScorP1R1()
        DataGridView1.Rows(row).Cells(3).Value = ScorP2R1()
        DataGridView1.Rows(row).Cells(5).Value = ScorP3R1()
        DataGridView1.Rows(row).Cells(7).Value = ScorP4R1()
        DataGridView1.Rows(row).Cells(9).Value = ScorP5R1()
        DataGridView1.Rows(row).Cells(11).Value = ScorP6R1()
        row = row + 1

    End Sub
    Private Sub btnUpdR1()

    End Sub
End Class