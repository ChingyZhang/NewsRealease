/*
	用于发送Ajax请求 
 */


/**
 * [ajax_post 用post方式发送ajax请求] 
 * @param  {[array]} data [数据]
 * @param  {[string]} url  [请求地址]
 * @param  {[string]} call_back  [回调函数]
 * @param  {[string]} data_type     [返回的数据格式]
 * @return {[type]}      错误的返回json 有flag和message 属性
 *                       错误的返回html 有id=flag和id=message div元素
 */
 function ajax_post(post_data,post_url,call_function,data_type){
 	//return ;
 	//console.log(post_data);
 	$.post(post_url,post_data,function(data){
								 			//返回JSON 数据格式
								 			if(data_type=="json"){
								 				//console.log(data);
								 				var flag=data.flag;
									 			if(flag==false){
									 				//创建弹出层
									 				var containerdiv=$("<div></div>");
									 					containerdiv.attr("id","dialogdiv");
									 				var messagediv=$("<div ></div>");
									 				var spantext=$("<span></span>");
									 					spantext.text(data.message);
									 					messagediv.addClass('text-center').addClass('text-danger');	
									 				//组件dialog
									 				spantext.appendTo(messagediv);
									 				messagediv.appendTo(containerdiv);

									 				containerdiv.dialog({
									 					show: "slide",
									 					title: "提示信息",
									 					close: function(){
									 						$(this).dialog('close');
									 					}
									 				});

									 			}else if(call_function){
									 				call_function(data);
									 			}
								 			}
								 			//返回html数据格式
								 			if(data_type=="html"){
								 				var obj = $(data);
								    			var flag = $.trim(obj.children("#flag").html());
									 			if(flag=="false"){
									 				//创建弹出层
									 				var containerdiv=$("<div></div>");
									 					containerdiv.attr("id","dialogdiv");
									 				var messagediv=$("<div></div>");
									 				//组件dialog
									 				$.trim(obj.children("#message")).appendTo(messagediv);
									 				messagediv.appendTo(containerdiv);

									 				containerdiv.dialog({
									 					show: "slide",
									 					title: "提示信息",
									 					close:function() {
									 						$(this).dialog('close');
									 					}
									 				});

									 			}else if(call_function){
									 				call_function(data);
									 			}
								 			}
								 			
								 		},data_type
 	);
 }


/**
 * [ajax_get 用get方式发送ajax请求] 
 * @param  {[array]} data [数据]
 * @param  {[string]} url  [请求地址]
 * @param  {[string]} call_back  [回调函数]
 * @param  {[string]} data_type   [返回的数据格式]
 * @return {[type]}      [返回数据]
 */
 function ajax_get(get_data,get_url,call_function,data_type){
 	$.get(get_url,get_data,function(data){
								 			//返回JSON 数据格式
								 			if(data_type=="json"){
								 				console.log(data);
								 				var flag=data.flag;
									 			if(flag==false){
									 				//创建弹出层
									 				var containerdiv=$("<div></div>");
									 					containerdiv.attr("id","dialogdiv");
									 				var messagediv=$("<div ></div>");
									 				var spantext=$("<span></span>");
									 					spantext.text(data.message);
									 					messagediv.addClass('text-center').addClass('text-danger');	
									 				//组件dialog
									 				spantext.appendTo(messagediv);
									 				messagediv.appendTo(containerdiv);

									 				containerdiv.dialog({
									 					show: "slide",
									 					title: "提示信息",
									 					close: function(){
									 						$(this).dialog('close');
									 					}
									 				});

									 			}else if(call_function){
									 				call_function(data);
									 			}
								 			}
								 			//返回html数据格式
								 			if(data_type=="html"){
								 				var obj = $(data);
								    			var flag = $.trim(obj.children("#flag").html());
									 			if(flag=="false"){
									 				//创建弹出层
									 				var containerdiv=$("<div></div>");
									 					containerdiv.attr("id","dialogdiv");
									 				var messagediv=$("<div></div>");
									 				//组件dialog
									 				$.trim(obj.children("#message")).appendTo(messagediv);
									 				messagediv.appendTo(containerdiv);

									 				containerdiv.dialog({
									 					show: "slide",
									 					title: "提示信息",
									 					close:function() {
									 						$(this).dialog('close');
									 					}
									 				});

									 			}else if(call_function){
									 				call_function(data);
									 			}
								 			}
								 			
								 		},data_type
 	);
 }
