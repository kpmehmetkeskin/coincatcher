<%@ Page Title="Coin Market Math" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CoinCatcher._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" style="background-color: #000000">
        <div class="col-md-12">
            <p class="lead" style="color: #FFFFFF">This algorithm calculates the instant increase powers of the coins. Coin Market Math, allows you to catch a sudden graphic explosion. Don't miss a sudden graphic explosion! Catch the coin before rising..</p>
        </div>
    </div>

    <div class="row" style="background-color: #C0C0C0">
        <div class="col-md-12" style="margin: 15px auto auto auto;">
            <p>
                <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/Resources/header2biggif.gif" Width="100%" />
            </p>
        </div>
    </div>

    <div class="row" style="border-style: groove hidden groove hidden; border-width: medium; border-color: #000000; background-color: #C0C0C0;">
        <div class="col-md-3">
            <p style="font-family: Calibri; color: #000000; font-weight: bolder; font-size: 16px;">[t] = Now</p>
        </div>
        <div class="col-md-3">
            <p style="font-family: Calibri; color: #000000; font-weight: bolder; font-size: 16px;">[t-1] = Now - 1(sec)</p>
        </div>
         <div class="col-md-3">
            <p style="font-family: Calibri; color: #000000; font-weight: bolder; font-size: 16px;">[Pw%] = Percentage of Power Increase</p>
        </div>
         <div class="col-md-3">
            <p style="font-family: Calibri; color: #000000; font-weight: bolder; font-size: 16px;">Time Interval = Seconds</p>
        </div>
    </div>
    
    <div class="row" style="background-color: #C0C0C0">
        <div class="col-md-12" runat="server">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"> 
            <Triggers>
                <asp:AsyncPostBackTrigger  ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate> 
                <div class="col-md-8">
                    <table class="tftable" border="1">
                        <tr><th colspan="8">COIN POWER ALGORITHM</th></tr>
                        <tr><th> </th><th>COIN-BTC</th><th>POWER (Pw%)</th><th>t-4</th><th>t-3</th><th>t-2</th><th>t-1</th><th>t (now)</th></tr>
                        <% for (int i = 0; i < getList().Count; i++) { %>
                            <tr>
                                <td><%=(i+1).ToString() %></td>
                                <td><%=getList()[i].symbol %></td>
                                <td><%=getList()[i].incrementPower %></td>
                                <td><img src="Resources/<%=getList()[i].incrementHistory[0].ToString()%>.jpg" style = "height:20px;"></td>
                                <td><img src="Resources/<%=getList()[i].incrementHistory[1].ToString()%>.jpg" style = "height:20px;"></td>
                                <td><img src="Resources/<%=getList()[i].incrementHistory[2].ToString()%>.jpg" style = "height:20px;"></td>
                                <td><img src="Resources/<%=getList()[i].incrementHistory[3].ToString()%>.jpg" style = "height:20px;"></td>
                                <td><img src="Resources/<%=getList()[i].incrementHistory[4].ToString()%>.jpg" style = "height:20px;"></td>
                            </tr>
                       <% } %>
                    </table>
                </div>
                <div class="col-md-4">
                    <table class="tftable2" border="1">
                        <tr><th colspan="2">POWERFUL INCREMENT HISTORY</th></tr>
                        <tr><th>Coin</th><th>Date(GMT+2)</th></tr>
                        <% for (int i = pumpedCoins.Count-1; i >= 0; i--) {%>
                            <tr>
                                <td><%=pumpedCoins.ElementAt(i).symbol%></td>
                                <td><%=pumpedCoins.ElementAt(i).date%></td>
                            </tr>
                       <% } %>
                    </table>
                </div>
            </ContentTemplate> 
            </asp:UpdatePanel> 
            <asp:Timer ID="Timer1" runat="server" Interval="1000">
            </asp:Timer> 
        </div>
    </div>
    <div class="row" style="background-color: #C0C0C0">
        <p style="color: #C0C0C0; font-size: xx-small">bitcoin, ethereum, ripple, bitcoin cash, litecoin, neo, cardano, stellar, dash, monero, nem, ethereum classic, qtum, lisk, btc, eth, xrp, bcc, bch, ltc, ada, xlm, miota, xmr, xem, etc, lsk, coinmarketmath, coin, market, math, capitalizations, graph, coin graph, crypto currency estimates, con, mat, markt, statistics</p>
    </div>
</asp:Content>
