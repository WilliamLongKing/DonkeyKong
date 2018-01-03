Module Mariostuff
    Structure marioType
        Dim speed As Point
        Dim floattime As Integer
        Dim picNum As Integer
        Dim facingRight As Boolean
        Dim onLadder As Boolean
        Dim floating As Boolean
        Dim onFloor As Boolean
    End Structure
    Structure floortype
        Dim x As Single
        Dim y As Single
        Dim slope As Single
        Dim leftedge As Integer
        Dim rightedge As Integer
    End Structure

    Public mstuff As marioType
End Module
