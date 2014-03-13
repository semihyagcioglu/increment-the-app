<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostTask.aspx.cs" Inherits="increment_the_app.PostTask" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">

    <script src="js/postTask.js"></script>

    <meta charset="utf-8">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
  
    <script>
        $(document).ready(function () {
            $("#Notes").click(function () {
                $("#PrivateNotes").slideToggle();
            });
        })

        $(function () {
            $("#datepicker").datepicker({ dateFormat: "yy-mm-dd" });
        });
    </script>

</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">

    <h4 class="ch4">Lütfen Gerekli İş Bilgilerini Giriniz...</h4>
  <hr />
    <div class="form-group">
        <div id="warningMessagePostedTask" class="alert alert-success" style="display: none;">
            İş başarıyla eklendi :)
        </div>
    </div>
    <form role="form">
        <div class="form-group">
            <%--<label class="text-primary">Yapılmak İstenen İş</label>--%>
            <input type="text" class="form-control" id="InputTitle" style="width: 650px;margin: 0 auto;" placeholder="Yapılmak istenen iş...">
        </div>
        <div class="form-group">
           <%-- <label class="text-primary">İşin Detayı</label>--%>
            <textarea class="form-control" id="InputTitleDetail" style="width: 650px;margin: 0 auto;" placeholder="Lütfen yapılacak işin detaylarını girin..." rows="3"></textarea>
        </div>
    </form>  

    <form role="form">
        <div class="form-group" style="width: 650px;margin: 0 auto;margin-bottom: 10px;">           
            <span class="label label-info" id="Notes" style="width: 650px;margin: 0 auto;">+ İşiniz için özel notunuz var mı?</span>
           <textarea class="form-control" style="display:none;" id="PrivateNotes" placeholder="Özel notunuz varsa lütfen belirtin..." rows="3"></textarea>
        </div>        
    </form> 
    
        <form role="form">
            <div class="form-group">
                <%--<label class="text-primary">Nerede Yapılacak</label>--%>
                <input id="Location" class="form-control" style="width: 650px;margin: 0 auto;" placeholder="Nerede yapılsın..." type="text" />              
            </div>
        </form>
    <form role="form">
            <div class="form-group" id="date" style="width:263px; float:left; margin-right:10px; height:auto;">
        <label class="text-primary" style="margin-left:10px;">İşin Teslim Tarihi</label>      
            <div class="form-group">
                <input id="datepicker" type="text" class="form-control" style="margin-left:10px;" placeholder="Tarih Seçin" required />
            </div>
                </div>
        </form>  

    <form role="form">
            <div class="form-group" id="hour" style="float:left; width:263px; margin-left:40px; ">
        <label class="text-primary">İşin Teslim Saati</label>      
            <div class="form-group">
                <select id="InsertHour" class="form-control">
                    <option>00:00</option>
                    <option>01:00</option>
                    <option>02:00</option>
                    <option>03:00</option>
                    <option>04:00</option>
                    <option>05:00</option>
                    <option>06:00</option>
                    <option>07:00</option>
                    <option>08:00</option>
                    <option>09:00</option>
                    <option>10:00</option>
                    <option>11:00</option>
                    <option>12:00</option>
                    <option>13:00</option>
                    <option>14:00</option>
                    <option>15:00</option>
                    <option>16:00</option>
                    <option>17:00</option>
                    <option>18:00</option>
                    <option>19:00</option>
                    <option>20:00</option>
                    <option>21:00</option>
                    <option>22:00</option>
                    <option>23:00</option>

                </select>              
            </div>
                </div>
        </form>
  
        <form role="form">
            <div class="form-group" id="money" style="width:600px; margin-top:auto;">
                
                <label class="text-primary" style="margin-left:10px;">Ücret</label>
               <div class="text-primary"><input class="numeric integer optional" style="height:40px; width:50px; margin-left:15px; text-align:center;" id="taskPrice" name="task[named_price]" step="1" type="number" value="20" />
                  
                   <label for="task_named_price">(TL) Bu iş için ne kadar ödemeyi düşünüyorsun?</label>

               </div>            
            </div>            
        </form>
       <div style="width:300px; margin:0 auto;">
        <div id="btnTaskSave" style="width:300px; margin-bottom:auto; margin-top:auto; text-align:center;"  class="btn btn-lg btn-success btn-block">Kaydet ve Teklif Al</div></div>
 <br />
</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>
