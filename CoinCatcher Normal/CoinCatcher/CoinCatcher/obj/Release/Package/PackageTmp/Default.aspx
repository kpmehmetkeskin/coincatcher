﻿<%@ Page Title="Coin Market Math" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CoinCatcher._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" style="background-color: #000000">
        <div class="col-md-12">
            <p class="lead" style="color: #FFFFFF">This algorithm calculates the instant increase powers of the coins. Coin Market Math, allows you to catch a sudden graphic explosion. Don't miss a sudden graphic explosion! Catch the coin before rising..</p>
            <p class="lead" style="color: #FFFFFF">Do not miss the rising graph while looking at the individual coin graphs. You can see them all on coinmarketmath.</p>
        </div>
    </div>

    <div class="row" style="background-color: #000000">
        <a href="https://play.google.com/store/apps/details?id=com.futuremesalabs.coinmarketmath"><img src="Resources/googleplay.png" alt="Get it on GooglePlay" height="100" width="300"></a>
    </div>

    <div class="row" style="border-style: groove hidden groove hidden; border-width: medium; border-color: #000000; background-color: #C0C0C0;">
         <div class="col-md-6">
            <p style="font-family: Calibri; color: #000000; font-weight: bolder; font-size: 16px;">[Pw%] = Percentage of Power Increase</p>
        </div>
         <div class="col-md-6">
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
    
                
            <div class="row" style="border-style: hidden hidden groove hidden; border-width: medium; border-color: #000000; background-color: #C0C0C0; height:32px;">
                <div class="progress" style="height:30px">
                    <div class="progress-bar progress-bar-success" role="progressbar" style="width:<%=bullishBearishDTO.bullishPercent%>%">
                        <p style="padding-top:5px">Bullish(<%=bullishBearishDTO.bullishPercent%>%)</p>
                    </div>
                    <div class="progress-bar progress-bar-danger" role="progressbar" style="width:<%=bullishBearishDTO.bearishPercent%>%">
                        <p style="padding-top:5px">Bearish(<%=bullishBearishDTO.bearishPercent%>%)</p>
                    </div>
                </div>
            </div>

                <div class="col-md-8">
                    <table class="tftable" border="1">
                        <tr><th colspan="8">COIN POWER ALGORITHM</th></tr>
                        <tr><th> </th><th>COIN-BTC</th><th>PRICE-BTC</th><th>PRICE POWER(%)</th><th>OUR ADVICE</th><th>CHART PROGRESS</th></tr>
                        <% for (int i = 0; i < getList().Count; i++) { %>
                            <tr>
                        
                                <td><%=(i+1).ToString() %></td>
                                <td><a href="https://www.binance.com/en/trade/<%=getList()[i].Symbol %>_BTC" target="_blank"><span><%=getList()[i].Symbol %></span></a></td>
                                <td><%=getList()[i].Price %></td>
                                <td><%=getList()[i].PricePower %></td>
                                <%if (getList()[i].PricePower > 90) {%>
                                <td style="background-color:#00FFFF">STRONGLY BUY</td>
                                <%} else if (getList()[i].PricePower > 70) { %>
                                <td style="background-color:#98FB98">BUY</td>
                                <%} else if (getList()[i].PricePower > 50) { %>
                                <td style="background-color:#FFD700">DO NOT BUY</td>
                                <%} else if (getList()[i].PricePower > -1) { %>
                                <td style="background-color:#F08080">STRONGLY DO NOT BUY</td>
                                <%} %>

                                <%if (getList()[i].PricePower > 90) {%>
                                <td style="background-color:#00FFFF">EXPLONSION</td>
                                <%} else if (getList()[i].PricePower > 70) { %>
                                <td style="background-color:#98FB98">RISING STRONGLY</td>
                                <%} else if (getList()[i].PricePower > 50) { %>
                                <td style="background-color:#FFD700">RISING</td>
                                <%} else if (getList()[i].PricePower > -1) { %>
                                <td style="background-color:#F08080">STAGNANT</td>
                                <%} %>
                        </tr>
                       <% } %>
                    </table>
                </div>
                <div class="col-md-4">
                    <table class="tftable2" border="1">
                        <tr><th colspan="2">POWERFUL INCREMENT HISTORY</th></tr>
                        <tr><th>Coin</th><th>Date</th></tr>
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
            <asp:Timer ID="Timer1" runat="server" Interval="3000">
            </asp:Timer> 
        </div>
    </div>
    <div class="row" style="background-color: #C0C0C0">
        <p style="color: #C0C0C0; font-size: xx-small">bitcoin, ethereum, ripple, bitcoin cash, litecoin, neo, cardano, stellar, dash, monero, nem, ethereum classic, qtum, lisk, btc, eth, xrp, bcc, bch, ltc, ada, xlm, miota, xmr, xem, etc, lsk, coinmarketmath, coin, market, math, capitalizations, graph, coin graph, crypto currency estimates, con, mat, markt, statistics</p>
    </div>
</asp:Content>
