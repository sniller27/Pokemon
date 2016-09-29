<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pokemon Run Event</title>
    <link href="styles.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Pokémon Run Event"></asp:Label>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Sign up"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBoxAlias" runat="server"></asp:TextBox>
        <asp:Label ID="labelalias" runat="server" Text="Alias"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAlias" runat="server" ControlToValidate="TextBoxAlias" EnableClientScript="False" ErrorMessage="You need to choose an alias" ForeColor="#FF3300" ValidationGroup="signupvalidation"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <asp:Label ID="labelname" runat="server" Text="Name"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName" EnableClientScript="False" ErrorMessage="You need to fill out your name" ForeColor="#FF3300" ValidationGroup="signupvalidation"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server" ControlToValidate="TextBoxName" EnableClientScript="False" ErrorMessage="Your name can only contain letters" ForeColor="#FF3300" ValidationExpression="^([ \u00c0-\u01ffa-zA-Z'\-])+$" ValidationGroup="signupvalidation"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Label ID="labelgender" runat="server" Text="Gender"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" ControlToValidate="RadioButtonListGender" EnableClientScript="False" ErrorMessage="You need to choose a gender" ForeColor="#FF3300" ValidationGroup="signupvalidation"></asp:RequiredFieldValidator>
        <asp:RadioButtonList ID="RadioButtonListGender" runat="server" Width="83px">
            <asp:ListItem Value="Male"></asp:ListItem>
            <asp:ListItem Value="Female"></asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:TextBox ID="TextBoxAge" runat="server"></asp:TextBox>
        <asp:Label ID="labelage" runat="server" Text="Age"></asp:Label>
        <asp:RangeValidator ID="RangeValidatorAge" runat="server" ControlToValidate="TextBoxAge" EnableClientScript="False" ErrorMessage="You have to be at least 10 of age" ForeColor="#FF3300" MaximumValue="100" MinimumValue="10" Type="Integer" ValidationGroup="signupvalidation"></asp:RangeValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAge" runat="server" ControlToValidate="TextBoxAge" EnableClientScript="False" ErrorMessage="You have to fill out your age" ForeColor="#FF3300" ValidationGroup="signupvalidation"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
        <asp:Label ID="labelemail" runat="server" Text="Email"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="TextBoxEmail" EnableClientScript="False" ErrorMessage="You need to fill out your mail" ForeColor="#FF3300" ValidationGroup="signupvalidation"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="TextBoxEmail" EnableClientScript="False" ErrorMessage="Your mail is not written properly" ForeColor="#FF3300" ValidationExpression="[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" ValidationGroup="signupvalidation"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
        <asp:Label ID="labelpassword" runat="server" Text="Password"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="TextBoxPassword" EnableClientScript="False" ErrorMessage="You need to choose a password" ForeColor="#FF3300" ValidationGroup="signupvalidation"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorPasswordpattern" runat="server" ControlToValidate="TextBoxPassword" EnableClientScript="False" ErrorMessage="Your password has to contain at least 8 characters, 1 capital letter, 1 number and 1 special character" ForeColor="#FF3300" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,100}$" ValidationGroup="signupvalidation"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:TextBox ID="TextBoxPasswordRepeat" runat="server"></asp:TextBox>
        <asp:Label ID="Label7" runat="server" Text="Password confirmation"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPasswordRepeat" runat="server" ControlToValidate="TextBoxPasswordRepeat" EnableClientScript="False" ErrorMessage="You need to confirm your password" ForeColor="#FF3300" ValidationGroup="signupvalidation"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidatorPasswordConfirm" runat="server" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxPasswordRepeat" EnableClientScript="False" ErrorMessage="Your passwords have to be the same" ForeColor="#FF3300" ValidationGroup="signupvalidation"></asp:CompareValidator>
        <br />
        <br />
        <br />
        <asp:Button ID="ButtonSubmit" runat="server" Text="Create" Font-Size="Large" OnClick="ButtonSubmit_Click" ValidationGroup="signupvalidation" />
    
        <br />
        <asp:Label ID="printinfo" runat="server"></asp:Label>
        <br />
        <br />
        <div class="half">
            <p>Pokehunters</p>
            <asp:ListBox ID="personlistid" runat="server" Width="658px"></asp:ListBox></div>
        
        <div class="quarter">
            <p>Pokerhunter kids</p>
            <asp:ListBox ID="kidslistid" runat="server" Width="231px"></asp:ListBox></div>
        <div class="quarter">
            <p>Pokehunter adults</p>
            <asp:ListBox ID="adultlistid" runat="server" Width="237px"></asp:ListBox></div>
    
    </div>
    </form>
</body>
</html>
