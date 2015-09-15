<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="Edit.ascx.vb" Inherits="$rootnamespace$$safeprojectname$.Edit" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>
<div class="dnnForm dnnEditBasicSettings" id="dnnEditBasicSettings">
    <div class="dnnFormExpandContent dnnRight "><a href=""><%=LocalizeString("ExpandAll")%></a></div>

    <h2 id="dnnSitePanel-BasicSettings" class="dnnFormSectionHead dnnClear">
        <a href="" class="dnnSectionExpanded">
            <%=LocalizeString("BasicSettings")%></a></h2>
    <fieldset>
        <div class="dnnFormItem">
            <dnn:label ID="lblName" runat="server" />
            <asp:TextBox ID="txtName" runat="server" />
        </div>
        <div class="dnnFormItem">

            <dnn:label ID="lblDescription" runat="server" />
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5" Columns="20" />
        </div>
        <div class="dnnFormItem">
            <dnn:label ID="lblAssignedUser" runat="server" />
            <asp:DropDownList ID="ddlAssignedUser" runat="server" />
        </div>
    </fieldset>
</div>
<asp:LinkButton ID="btnSubmit" runat="server"
    OnClick="btnSubmit_Click" resourcekey="btnSubmit" CssClass="dnnPrimaryAction" />
<asp:LinkButton ID="btnCancel" runat="server"
    OnClick="btnCancel_Click" resourcekey="btnCancel" CssClass="dnnSecondaryAction" />

<script type="text/javascript">
    /*globals jQuery, window, Sys */
    (function ($, Sys) {
        function dnnEditBasicSettings() {
            $('#dnnEditBasicSettings').dnnPanels();
            $('#dnnEditBasicSettings .dnnFormExpandContent a').dnnExpandAll({ expandText: '<%=Localization.GetString("ExpandAll", LocalResourceFile)%>', collapseText: '<%=Localization.GetString("CollapseAll", LocalResourceFile)%>', targetArea: '#dnnEditBasicSettings' });
        }

        $(document).ready(function () {
            dnnEditBasicSettings();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                dnnEditBasicSettings();
            });
        });

    }(jQuery, window.Sys));
</script>
