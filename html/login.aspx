<%@ Page Language="C#" %>
<script runat="server">
    protected override void OnLoad(EventArgs e)
    {
        Response.Redirect("/Account/Login?"+Request.QueryString);
    }
</script>