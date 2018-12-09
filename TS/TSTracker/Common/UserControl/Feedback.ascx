<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Feedback.ascx.cs" Inherits="TSTracker.Common.UserControl.Feedback" %>
<div class="errorfeedback" style="<%=hideErrors()%>">
    <%=renderErrorList("<div>", "</div>")%></div>
<div class="feedback" style="<%=hideTasksComplete()%>">
    <%=renderTasksCompleted("<div>", "</div>")%></div>
<div class="infofeedback" style="<%=hideinfo()%>">
    <%=renderinfo("<div>", "</div>")%></div>
