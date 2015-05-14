
//使用此类 要引入Jquery   Jquery-UI bootstrap.css
var helper={
	alert:function(message){
			$(".ui-dialog").remove();
			//创建弹出层
			var containerdiv=$("<div></div>");
				containerdiv.attr("id","dialogdiv");
			var messagediv=$("<div ></div>");
			var spantext=$("<span></span>");
				spantext.text(message);
				messagediv.addClass('text-center').addClass('text-danger');	
			//组件dialog
			spantext.appendTo(messagediv);
			messagediv.appendTo(containerdiv);

			containerdiv.dialog({
				show: "slide",
				height: "auto",
				width : "auto",
				title: "提示信息",
				close: function(){
					$(this).dialog('close');
				}
			});
	},

	confirm:function(message){
			//创建弹出层
			var containerdiv=$("<div></div>");
				containerdiv.attr("id","dialogdiv");
			var messagediv=$("<div ></div>");
			var spantext=$("<span></span>");
				spantext.text(message);
				messagediv.addClass('text-center').addClass('text-warning');	
			//组件dialog
			spantext.appendTo(messagediv);
			messagediv.appendTo(containerdiv);

			containerdiv.dialog({
				show: "slide",
				height: "auto",
				width : "auto",
				title: "提示信息",
				close: function(){
					$(this).dialog('close');
				},
				buttons:{
					OK:function(){
						$(this).dialog('close');
						return true;
					},
					CANCEL:function(){
						$().dialog("close");
						return false;
					}
				}
			});
	},

	jump:function(url,message){
		if(message.length<=0){
			window.loaction.href=url;
		}else{
			helper.alert(message);
			window.location.href=url;
		}
	}


}