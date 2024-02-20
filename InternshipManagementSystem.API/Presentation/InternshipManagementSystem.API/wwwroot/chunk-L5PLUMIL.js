import{b as x,c as P,d as M}from"./chunk-Q57Y3WCD.js";import{a as K}from"./chunk-YSAPXRRZ.js";import{a as L,b as _,c as $}from"./chunk-EEM2TK5O.js";import{$ as f,Ba as O,C as h,Ca as m,D as v,E as A,F as g,H as U,I as w,M as E,N as I,Ta as F,Ya as J,ab as V,c as C,da as H,gb as B,h as b,i as S,ib as W,j as N,kb as z,l as T,n as R,na as l,oa as c,pa as d,sa as G,va as D}from"./chunk-IQTUD4L7.js";var Y=(()=>{let i=class i{constructor(e,n){this.httpClientService=e,this.toastrService=n}isLoggedIn(){return localStorage.getItem("userRole")!==null}loginAdvisor(e,n,r){return C(this,null,function*(){let s=this.httpClientService.post({controller:"users",action:"login"},{userName:e,password:n}),a=yield S(s);a&&localStorage.setItem("accessToken",a.token.accessToken),localStorage.setItem("userID",a.userID),localStorage.setItem("userTypeName",a.userTypeName),this.toastrService.message("Akademisyen Giri\u015Fi Ba\u015Far\u0131yla Sa\u011Flanm\u0131\u015Ft\u0131r.","Ho\u015Fgeldiniz!",{messageType:P.Success,position:M.TopRight}),r&&r()})}loginStudent(e,n,r){return C(this,null,function*(){let s=e,a=n,p=this.httpClientService.post({controller:"users",action:"login"},{userName:s,password:a}),u=yield S(p);u&&localStorage.setItem("accessToken",u.token.accessToken),localStorage.setItem("userID",u.userID),localStorage.setItem("userTypeName",u.userTypeName),this.toastrService.message("\xD6\u011Frenci Giri\u015Fi Ba\u015Far\u0131yla Sa\u011Flanm\u0131\u015Ft\u0131r.","Ho\u015Fgeldiniz!",{messageType:P.Success,position:M.TopRight}),r&&r()})}};i.\u0275fac=function(n){return new(n||i)(g(K),g(x))},i.\u0275prov=h({token:i,factory:i.\u0275fac,providedIn:"root"});let o=i;return o})();var j=new A("JWT_OPTIONS"),y=(()=>{class o{constructor(t=null){this.tokenGetter=t&&t.tokenGetter||function(){}}urlBase64Decode(t){let e=t.replace(/-/g,"+").replace(/_/g,"/");switch(e.length%4){case 0:break;case 2:{e+="==";break}case 3:{e+="=";break}default:throw new Error("Illegal base64url string!")}return this.b64DecodeUnicode(e)}b64decode(t){let e="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",n="";if(t=String(t).replace(/=+$/,""),t.length%4===1)throw new Error("'atob' failed: The string to be decoded is not correctly encoded.");for(let r=0,s,a,p=0;a=t.charAt(p++);~a&&(s=r%4?s*64+a:a,r++%4)?n+=String.fromCharCode(255&s>>(-2*r&6)):0)a=e.indexOf(a);return n}b64DecodeUnicode(t){return decodeURIComponent(Array.prototype.map.call(this.b64decode(t),e=>"%"+("00"+e.charCodeAt(0).toString(16)).slice(-2)).join(""))}decodeToken(t=this.tokenGetter()){return t instanceof Promise?t.then(e=>this._decodeToken(e)):this._decodeToken(t)}_decodeToken(t){if(!t||t==="")return null;let e=t.split(".");if(e.length!==3)throw new Error("The inspected token doesn't appear to be a JWT. Check to make sure it has three parts and see https://jwt.io for more.");let n=this.urlBase64Decode(e[1]);if(!n)throw new Error("Cannot decode the token.");return JSON.parse(n)}getTokenExpirationDate(t=this.tokenGetter()){return t instanceof Promise?t.then(e=>this._getTokenExpirationDate(e)):this._getTokenExpirationDate(t)}_getTokenExpirationDate(t){let e;if(e=this.decodeToken(t),!e||!e.hasOwnProperty("exp"))return null;let n=new Date(0);return n.setUTCSeconds(e.exp),n}isTokenExpired(t=this.tokenGetter(),e){return t instanceof Promise?t.then(n=>this._isTokenExpired(n,e)):this._isTokenExpired(t,e)}_isTokenExpired(t,e){if(!t||t==="")return!0;let n=this.getTokenExpirationDate(t);return e=e||0,n===null?!1:!(n.valueOf()>new Date().valueOf()+e*1e3)}getAuthScheme(t,e){return typeof t=="function"?t(e):t}}return o.\u0275fac=function(t){return new(t||o)(g(j))},o.\u0275prov=h({token:o,factory:o.\u0275fac}),o})(),Q=o=>o instanceof Promise?R(()=>o):b(o),ne=(()=>{class o{constructor(t,e,n){this.jwtHelper=e,this.document=n,this.standardPorts=["80","443"],this.tokenGetter=t.tokenGetter,this.headerName=t.headerName||"Authorization",this.authScheme=t.authScheme||t.authScheme===""?t.authScheme:"Bearer ",this.allowedDomains=t.allowedDomains||[],this.disallowedRoutes=t.disallowedRoutes||[],this.throwNoTokenError=t.throwNoTokenError||!1,this.skipWhenExpired=t.skipWhenExpired}isAllowedDomain(t){let e=new URL(t.url,this.document.location.origin);if(e.host===this.document.location.host)return!0;let n=`${e.hostname}${e.port&&!this.standardPorts.includes(e.port)?":"+e.port:""}`;return this.allowedDomains.findIndex(r=>typeof r=="string"?r===n:r instanceof RegExp?r.test(n):!1)>-1}isDisallowedRoute(t){let e=new URL(t.url,this.document.location.origin);return this.disallowedRoutes.findIndex(n=>{if(typeof n=="string"){let r=new URL(n,this.document.location.origin);return r.hostname===e.hostname&&r.pathname===e.pathname}return n instanceof RegExp?n.test(t.url):!1})>-1}handleInterception(t,e,n){let r=this.jwtHelper.getAuthScheme(this.authScheme,e);if(!t&&this.throwNoTokenError)throw new Error("Could not get token from tokenGetter function.");let s=b(!1);return this.skipWhenExpired&&(s=t?Q(this.jwtHelper.isTokenExpired(t)):b(!0)),t?s.pipe(N(a=>a&&this.skipWhenExpired?e.clone():e.clone({setHeaders:{[this.headerName]:`${r}${t}`}})),T(a=>n.handle(a))):n.handle(e)}intercept(t,e){if(!this.isAllowedDomain(t)||this.isDisallowedRoute(t))return e.handle(t);let n=this.tokenGetter(t);return Q(n).pipe(T(r=>this.handleInterception(r,t,e)))}}return o.\u0275fac=function(t){return new(t||o)(g(j),g(y),g(F))},o.\u0275prov=h({token:o,factory:o.\u0275fac}),o})(),Me=(()=>{class o{constructor(t){if(t)throw new Error("JwtModule is already loaded. It should only be imported in your application's main module.")}static forRoot(t){return{ngModule:o,providers:[{provide:V,useClass:ne,multi:!0},t.jwtOptionsProvider||{provide:j,useValue:t.config},y]}}}return o.\u0275fac=function(t){return new(t||o)(g(o,12))},o.\u0275mod=w({type:o}),o.\u0275inj=v({}),o})();var Z=(()=>{let i=class i{getUserRole(){let e=localStorage.getItem("userTypeName");return e||"guest"}constructor(e){this.jwtHelper=e}identityCheck(){let e=localStorage.getItem("accessToken"),n;try{n=this.jwtHelper.isTokenExpired(e)}catch{n=!0}X=e!=null&&!n}get isAuthenticated(){return this.identityCheck(),X}};i.\u0275fac=function(n){return new(n||i)(g(y))},i.\u0275prov=h({token:i,factory:i.\u0275fac,providedIn:"root"});let o=i;return o})(),X;var q=(()=>{let i=class i extends L{constructor(e,n,r,s,a,p){super(r),this.userService=e,this.router=n,this.authService=s,this.activatedRoute=a,this.toastrService=p}ngOnInit(){}loginAdvisor(e,n){return C(this,null,function*(){this.showSpinner(_.BallNewton),this.isValidEmail(e)?yield this.userService.loginAdvisor(e,n,()=>{this.authService.identityCheck(),this.activatedRoute.queryParams.subscribe(r=>{let s=r.returnUrl;s&&this.router.navigate([s])}),this.hideSpinner(_.BallNewton)}).then(()=>{this.redirectToAdvisorPortal()}).catch(()=>{this.toastrService.message("Kullan\u0131c\u0131 Ad\u0131 Veya \u015Eifre Hatal\u0131!","Hatal\u0131 Giri\u015F!",{messageType:P.Error,position:M.TopRight})}):alert("Email Adresi Do\u011Fru De\u011Fil!")})}loginStudent(e,n){return C(this,null,function*(){this.showSpinner(_.BallNewton);var r=!isNaN(Number(e));r?yield this.userService.loginStudent(e,n,()=>{this.authService.identityCheck(),this.activatedRoute.queryParams.subscribe(s=>{let a=s.returnUrl;a&&this.router.navigate([a])}),this.hideSpinner(_.BallNewton)}).then(()=>{this.redirectToStudentPortal()}).catch(()=>{this.toastrService.message("\xD6\u011Frenci No Veya \u015Eifre Hatal\u0131!","Hatal\u0131 Giri\u015F!",{messageType:P.Error,position:M.TopRight})}):alert("\xD6\u011Frenci No Do\u011Fru De\u011Fil!")})}redirectToStudentPortal(){this.router.navigateByUrl("/student-portal")}redirectToAdvisorPortal(){this.router.navigateByUrl("/advisor-portal")}isValidEmail(e){var n=/^[^\s@]+@[^\s@]+\.[^\s@]+$/;return n.test(e)}};i.\u0275fac=function(n){return new(n||i)(f(Y),f(W),f($),f(Z),f(B),f(x))},i.\u0275cmp=U({type:i,selectors:[["app-login"]],features:[H],decls:49,vars:0,consts:[["lang","en"],["charset","UTF-8"],["name","viewport","content","width=device-width, initial-scale=1.0"],["rel","stylesheet","href","/src/assets/css/style.css"],[1,"login-wrap"],[1,"login-html"],["id","tab-1","type","radio","name","tab","checked","",1,"sign-in"],["for","tab-1",1,"tab"],["id","tab-2","type","radio","name","tab",1,"sign-up"],["for","tab-2",1,"tab"],[1,"login-form"],[1,"sign-in-htm"],[1,"group"],["for","user",1,"label"],["id","user","type","text","placeholder","\xD6\u011Frenci No",1,"input"],["txtStudentNo",""],["for","pass",1,"label"],["id","pass","type","password","data-type","password","placeholder","\u015Eifre",1,"input"],["txtPasswordStudent",""],["id","check","type","checkbox","checked","",1,"check"],["type","submit","value","Giri\u015F Yap",1,"button",3,"click"],[1,"hr"],[1,"sign-up-htm"],["id","user","type","text","placeholder","Kullan\u0131c\u0131 Ad\u0131",1,"input"],["txtUserName",""],["txtPasswordAdvisor",""],[1,"foot-lnk"]],template:function(n,r){if(n&1){let s=G();l(0,"html",0)(1,"head"),d(2,"meta",1)(3,"meta",2),l(4,"title"),m(5,"Login Page"),c(),d(6,"link",3),c(),l(7,"body")(8,"div",4)(9,"div",5),d(10,"input",6),l(11,"label",7),m(12,"\xD6\u011Frenci Giri\u015Fi"),c(),d(13,"input",8),l(14,"label",9),m(15,"Akademisyen Giri\u015Fi"),c(),l(16,"div",10)(17,"div",11)(18,"div",12)(19,"label",13),m(20,"\xD6\u011Frenci No:"),c(),d(21,"input",14,15),c(),l(23,"div",12)(24,"label",16),m(25,"\u015Eifre:"),c(),d(26,"input",17,18),c(),l(28,"div",12),d(29,"input",19),c(),l(30,"div",12)(31,"input",20),D("click",function(){E(s);let p=O(22),u=O(27);return I(r.loginStudent(p.value,u.value))}),c()(),d(32,"div",21),c(),l(33,"div",22)(34,"div",12)(35,"label",13),m(36,"Kullan\u0131c\u0131 Ad\u0131:"),c(),d(37,"input",23,24),c(),l(39,"div",12)(40,"label",16),m(41,"\u015Eifre:"),c(),d(42,"input",17,25),c(),l(44,"div",12)(45,"input",20),D("click",function(){E(s);let p=O(38),u=O(43);return I(r.loginAdvisor(p.value,u.value))}),c()(),d(46,"div",21)(47,"div",21)(48,"div",26),c()()()()()()}},styles:['body[_ngcontent-%COMP%]{margin:0;color:#5b0a1a;background:linear-gradient(to right,#212020,#5b0a1a);font:600 16px/18px Open Sans,sans-serif;display:flex;align-items:center;height:100vh}*[_ngcontent-%COMP%], [_ngcontent-%COMP%]:after, [_ngcontent-%COMP%]:before{box-sizing:border-box}.clearfix[_ngcontent-%COMP%]:after, .clearfix[_ngcontent-%COMP%]:before{content:"";display:table}.clearfix[_ngcontent-%COMP%]:after{clear:both;display:block}a[_ngcontent-%COMP%]{color:inherit;text-decoration:none}.login-wrap[_ngcontent-%COMP%]{width:100%;margin:auto;max-width:600px;min-height:670px;position:relative;box-shadow:0 12px 15px #0000003d,0 17px 50px #00000030}.login-html[_ngcontent-%COMP%]{width:100%;height:100%;position:absolute;padding:90px 70px 50px;background:#f8f9fa}.login-html[_ngcontent-%COMP%]   .sign-in-htm[_ngcontent-%COMP%], .login-html[_ngcontent-%COMP%]   .sign-up-htm[_ngcontent-%COMP%]{inset:0;position:absolute;transform:rotateY(180deg);backface-visibility:hidden;transition:all .4s linear}.login-html[_ngcontent-%COMP%]   .sign-in[_ngcontent-%COMP%], .login-html[_ngcontent-%COMP%]   .sign-up[_ngcontent-%COMP%], .login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   .check[_ngcontent-%COMP%]{display:none}.login-html[_ngcontent-%COMP%]   .tab[_ngcontent-%COMP%], .login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   .label[_ngcontent-%COMP%], .login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   .button[_ngcontent-%COMP%]{text-transform:uppercase}.login-html[_ngcontent-%COMP%]   .tab[_ngcontent-%COMP%]{font-size:22px;padding-bottom:5px;margin:0 15px 10px 0;display:inline-block;border-bottom:2px solid transparent}.login-html[_ngcontent-%COMP%]   .sign-in[_ngcontent-%COMP%]:checked + .tab[_ngcontent-%COMP%], .login-html[_ngcontent-%COMP%]   .sign-up[_ngcontent-%COMP%]:checked + .tab[_ngcontent-%COMP%]{color:#5b0a1a;border-color:#5b0a1a}.login-form[_ngcontent-%COMP%]{min-height:345px;position:relative;perspective:1000px;transform-style:preserve-3d}.login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]{margin-bottom:15px}.login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   .label[_ngcontent-%COMP%], .login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   .input[_ngcontent-%COMP%], .login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   .button[_ngcontent-%COMP%]{width:100%;display:block}.login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   .input[_ngcontent-%COMP%], .login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   .button[_ngcontent-%COMP%]{padding:15px 20px;border-radius:25px;background:linear-gradient(to right,rgb(255,255,255))}.login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   input[data-type=password][_ngcontent-%COMP%]{text-security:circle;-webkit-text-security:circle}.login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   .label[_ngcontent-%COMP%]{color:#5b0a1a;font-size:12px}.login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   .button[_ngcontent-%COMP%]{background:#8c0f15;color:#fff}.login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   label[_ngcontent-%COMP%]   .icon[_ngcontent-%COMP%]{width:15px;height:15px;border-radius:2px;position:relative;display:inline-block;background:rgba(171,22,22,.1)}.login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   label[_ngcontent-%COMP%]   .icon[_ngcontent-%COMP%]:before, .login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   label[_ngcontent-%COMP%]   .icon[_ngcontent-%COMP%]:after{content:"";width:10px;height:2px;background:#fff;position:absolute;transition:all .2s ease-in-out 0s}.login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   label[_ngcontent-%COMP%]   .icon[_ngcontent-%COMP%]:before{left:3px;width:5px;bottom:6px;transform:scale(0) rotate(0)}.login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   label[_ngcontent-%COMP%]   .icon[_ngcontent-%COMP%]:after{top:6px;right:0;transform:scale(0) rotate(0)}.login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   .check[_ngcontent-%COMP%]:checked + label[_ngcontent-%COMP%]{color:#fff}.login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   .check[_ngcontent-%COMP%]:checked + label[_ngcontent-%COMP%]   .icon[_ngcontent-%COMP%]:before{transform:scale(1) rotate(45deg)}.login-form[_ngcontent-%COMP%]   .group[_ngcontent-%COMP%]   .check[_ngcontent-%COMP%]:checked + label[_ngcontent-%COMP%]   .icon[_ngcontent-%COMP%]:after{transform:scale(1) rotate(-45deg)}.login-html[_ngcontent-%COMP%]   .sign-in[_ngcontent-%COMP%]:checked + .tab[_ngcontent-%COMP%] + .sign-up[_ngcontent-%COMP%] + .tab[_ngcontent-%COMP%] + .login-form[_ngcontent-%COMP%]   .sign-in-htm[_ngcontent-%COMP%]{transform:rotate(0)}.login-html[_ngcontent-%COMP%]   .sign-up[_ngcontent-%COMP%]:checked + .tab[_ngcontent-%COMP%] + .login-form[_ngcontent-%COMP%]   .sign-up-htm[_ngcontent-%COMP%]{transform:rotate(0)}.hr[_ngcontent-%COMP%]{height:2px;margin:60px 0 50px;background:rgba(255,255,255,.2)}.foot-lnk[_ngcontent-%COMP%]{text-align:center}']});let o=i;return o})();var Te=(()=>{let i=class i{};i.\u0275fac=function(n){return new(n||i)},i.\u0275mod=w({type:i}),i.\u0275inj=v({imports:[J,z.forChild([{path:"",component:q}])]});let o=i;return o})();export{y as a,Me as b,Z as c,Te as d};
