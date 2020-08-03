(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./$$_lazy_route_resource lazy recursive":
/*!******************************************************!*\
  !*** ./$$_lazy_route_resource lazy namespace object ***!
  \******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/app-routing.module.ts":
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
/*! exports provided: AppRoutingModule, routableComponents */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppRoutingModule", function() { return AppRoutingModule; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "routableComponents", function() { return routableComponents; });
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _river_list_river_list_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./river-list/river-list.component */ "./src/app/river-list/river-list.component.ts");
/* harmony import */ var _river_detail_river_detail_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./river-detail/river-detail.component */ "./src/app/river-detail/river-detail.component.ts");
/* harmony import */ var _favorites_favorites_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./favorites/favorites.component */ "./src/app/favorites/favorites.component.ts");
/* harmony import */ var _profile_profile_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./profile/profile.component */ "./src/app/profile/profile.component.ts");








const routes = [
    { path: '', pathMatch: 'full', component: _river_list_river_list_component__WEBPACK_IMPORTED_MODULE_2__["RiverListComponent"] },
    { path: 'river/:id', component: _river_detail_river_detail_component__WEBPACK_IMPORTED_MODULE_3__["RiverDetailComponent"] },
    { path: 'favorites', component: _favorites_favorites_component__WEBPACK_IMPORTED_MODULE_4__["FavoritesComponent"] },
    { path: 'profile', component: _profile_profile_component__WEBPACK_IMPORTED_MODULE_5__["ProfileComponent"] },
    { path: '**', pathMatch: 'full', redirectTo: '' }
];
class AppRoutingModule {
}
AppRoutingModule.ɵmod = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineNgModule"]({ type: AppRoutingModule });
AppRoutingModule.ɵinj = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineInjector"]({ factory: function AppRoutingModule_Factory(t) { return new (t || AppRoutingModule)(); }, imports: [[_angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"].forRoot(routes)], _angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵsetNgModuleScope"](AppRoutingModule, { imports: [_angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"]], exports: [_angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"]] }); })();
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵsetClassMetadata"](AppRoutingModule, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"],
        args: [{
                imports: [_angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"].forRoot(routes)],
                exports: [_angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"]]
            }]
    }], null, null); })();
const routableComponents = [
    _river_list_river_list_component__WEBPACK_IMPORTED_MODULE_2__["RiverListComponent"],
    _river_detail_river_detail_component__WEBPACK_IMPORTED_MODULE_3__["RiverDetailComponent"],
    _favorites_favorites_component__WEBPACK_IMPORTED_MODULE_4__["FavoritesComponent"]
];


/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _auth_auth_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./auth/auth.service */ "./src/app/auth/auth.service.ts");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");





const _c0 = function () { return ["profile"]; };
function AppComponent_pre_2_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "pre");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "      ");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "a", 11);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](3, "\n        ");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](4, "img", 12);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](5, "\n      ");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](6, "\n      \n    ");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} if (rf & 2) {
    const profile_r3 = ctx.ngIf;
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction0"](2, _c0));
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpropertyInterpolate"]("src", profile_r3.picture, _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵsanitizeUrl"]);
} }
function AppComponent_a_6_Template(rf, ctx) { if (rf & 1) {
    const _r5 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "a", 13);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵlistener"]("click", function AppComponent_a_6_Template_a_click_0_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵrestoreView"](_r5); const ctx_r4 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵnextContext"](); return ctx_r4.auth.login(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "Login");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} }
function AppComponent_a_7_Template(rf, ctx) { if (rf & 1) {
    const _r7 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "a", 13);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵlistener"]("click", function AppComponent_a_7_Template_a_click_0_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵrestoreView"](_r7); const ctx_r6 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵnextContext"](); return ctx_r6.auth.logout(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "Logout");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} }
const _c1 = function () { return [""]; };
const _c2 = function (a0) { return { user: a0 }; };
const _c3 = function (a0) { return { data: a0 }; };
const _c4 = function () { return ["favorites"]; };
class AppComponent {
    constructor(auth) {
        this.auth = auth;
        this.title = 'paddle-finder';
    }
    ngOnInit() { }
    ngOnChanges(changes) {
        console.log(changes);
    }
    openNav() {
        document.getElementById("side-nav").style.width = "250px";
        document.body.style.backgroundColor = "rgba(0,0,0,0.4)";
    }
    closeNav() {
        document.getElementById("side-nav").style.width = "0";
        document.body.style.backgroundColor = "white";
    }
}
AppComponent.ɵfac = function AppComponent_Factory(t) { return new (t || AppComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_auth_auth_service__WEBPACK_IMPORTED_MODULE_1__["AuthService"])); };
AppComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({ type: AppComponent, selectors: [["app-root-paddle"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵProvidersFeature"]([]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵNgOnChangesFeature"]], decls: 22, vars: 19, consts: [["id", "side-nav", 1, "sidenav", 3, "focusout"], [4, "ngIf"], ["href", "javascript:void(0)", 1, "closebtn", 3, "click"], ["href", "javascript:void(0)", 3, "click", 4, "ngIf"], ["href", "javascript:void(0)", 3, "routerLink", "state"], [1, "banner"], [2, "padding-left", "8px", "top", "32px", "position", "relative"], [1, "hamburger", 2, "cursor", "pointer", 3, "click"], [1, "title"], [1, "subtitle"], [1, "outlet"], ["href", "javascript:void(0)", 3, "routerLink"], ["alt", "avatar", 1, "avatar", 2, "height", "36px", "border-radius", "16px", 3, "src"], ["href", "javascript:void(0)", 3, "click"]], template: function AppComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "div", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵlistener"]("focusout", function AppComponent_Template_div_focusout_1_listener() { return ctx.closeNav(); });
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](2, AppComponent_pre_2_Template, 7, 3, "pre", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpipe"](3, "async");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](4, "a", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵlistener"]("click", function AppComponent_Template_a_click_4_listener() { return ctx.closeNav(); });
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](5, "\u00D7");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](6, AppComponent_a_6_Template, 2, 0, "a", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](7, AppComponent_a_7_Template, 2, 0, "a", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](8, "a", 4);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](9, "search");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](10, "a", 4);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](11, "favorites");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](12, "div", 5);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](13, "div", 6);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](14, "span", 7);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵlistener"]("click", function AppComponent_Template_span_click_14_listener() { return ctx.openNav(); });
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](15, "h1");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](16, "span", 8);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](17, "checking water conditions is hard");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](18, "h3", 9);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](19, " Finding the information about whether it is safe (or fun) enough to get on your favorite river is hard. We're hoping that this makes that task a little more painless so you can spend more time enjoying the outdoors. ");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](20, "div", 10);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](21, "router-outlet");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpipeBind1"](3, 7, ctx.auth.userProfile$));
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](4);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", !ctx.auth.loggedIn);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", ctx.auth.loggedIn);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction0"](9, _c1))("state", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction1"](12, _c3, _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction1"](10, _c2, ctx.profile)));
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction0"](14, _c4))("state", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction1"](17, _c3, _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction1"](15, _c2, ctx.profile)));
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_2__["NgIf"], _angular_router__WEBPACK_IMPORTED_MODULE_3__["RouterLinkWithHref"], _angular_router__WEBPACK_IMPORTED_MODULE_3__["RouterOutlet"]], pipes: [_angular_common__WEBPACK_IMPORTED_MODULE_2__["AsyncPipe"]], styles: ["@import url(\"https://fonts.googleapis.com/css?family=Open+Sans\");\nbody[_ngcontent-%COMP%] {\n  font-family: Arial, Helvetica, sans-serif;\n}\nh1[_ngcontent-%COMP%] {\n  text-transform: uppercase;\n  color: white;\n  text-align: center;\n}\nh3[_ngcontent-%COMP%] {\n  text-transform: none;\n  text-align: center;\n}\n.search-box[_ngcontent-%COMP%] {\n  padding-bottom: 24px;\n  padding-right: 5%;\n  padding-left: 5%;\n  margin-left: 16px;\n  box-shadow: 0px 5px 12px 2px gray;\n}\n.search-bar[_ngcontent-%COMP%] {\n  left: 0px;\n  right: 0px;\n  width: 95%;\n  height: 52px;\n  margin-top: 12px;\n  border-color: #969696;\n}\n.results-list[_ngcontent-%COMP%] {\n  margin-left: 12%;\n  padding-top: 4px;\n  padding-bottom: 4px;\n}\n.banner[_ngcontent-%COMP%] {\n  position: absolute;\n  left: 0px;\n  top: 0px;\n  width: 100%;\n  height: 320px;\n  z-index: 282;\n  background-color: #051253;\n}\n.title[_ngcontent-%COMP%] {\n  top: 100px;\n}\n.subtitle[_ngcontent-%COMP%] {\n  top: 220px;\n  padding-left: 8%;\n  padding-right: 8%;\n  color: white;\n}\n.outlet[_ngcontent-%COMP%] {\n  position: relative;\n  top: 320px;\n  min-height: 800px;\n  margin-bottom: 15%;\n}\n.footer[_ngcontent-%COMP%] {\n  position: absolute;\n  min-height: 180px;\n  left: 0px;\n  bottom: -180px;\n  width: 100%;\n  background-color: #636363;\n}\n@media screen and (max-width: 924px) {\n  .banner[_ngcontent-%COMP%] {\n    position: absolute;\n    left: 0px;\n    top: 0px;\n    width: 100%;\n    height: 320px;\n    z-index: 282;\n    background-color: #051253;\n  }\n\n  .title[_ngcontent-%COMP%] {\n    position: relative;\n    top: 40px;\n  }\n\n  .subtitle[_ngcontent-%COMP%] {\n    position: relative;\n    top: 54px;\n    padding-left: 8%;\n    padding-right: 8%;\n  }\n\n  .outlet[_ngcontent-%COMP%] {\n    position: relative;\n    top: 320px;\n  }\n\n  .footer[_ngcontent-%COMP%] {\n    position: absolute;\n    left: 0px;\n    bottom: 0px;\n    width: 100%;\n  }\n}\n.search[_ngcontent-%COMP%] {\n  background-color: green;\n  left: 0px;\n  height: 480px;\n  width: 100%;\n  top: 480px;\n  position: absolute;\n}\n\n.sidenav[_ngcontent-%COMP%] {\n  height: 100%;\n  \n  width: 0;\n  \n  position: absolute;\n  \n  z-index: 400;\n  \n  top: 0;\n  \n  left: 0;\n  background-color: #818181;\n  \n  overflow-x: hidden;\n  \n  padding-top: 60px;\n  \n  transition: 0.5s;\n  \n}\n\n.sidenav[_ngcontent-%COMP%]   a[_ngcontent-%COMP%] {\n  padding: 8px 8px 8px 32px;\n  text-decoration: none;\n  font-size: 25px;\n  color: white;\n  display: block;\n  transition: 0.3s;\n}\n\n.sidenav[_ngcontent-%COMP%]   a[_ngcontent-%COMP%]:hover {\n  color: #f1f1f1;\n}\n\n.sidenav[_ngcontent-%COMP%]   .closebtn[_ngcontent-%COMP%] {\n  position: absolute;\n  top: 0;\n  right: 25px;\n  font-size: 36px;\n  margin-left: 50px;\n}\n\n#main[_ngcontent-%COMP%] {\n  transition: margin-left 0.5s;\n  padding: 20px;\n}\n\n@media screen and (max-height: 450px) {\n  .sidenav[_ngcontent-%COMP%] {\n    padding-top: 15px;\n  }\n\n  .sidenav[_ngcontent-%COMP%]   a[_ngcontent-%COMP%] {\n    font-size: 18px;\n  }\n}\n.hamburger[_ngcontent-%COMP%] {\n  position: relative;\n  display: inline-block;\n  width: 1.25em;\n  height: 0.8em;\n  margin-right: 0.3em;\n  border-top: 0.2em solid white;\n  border-bottom: 0.2em solid #fffefe;\n}\n.hamburger[_ngcontent-%COMP%]:before {\n  content: \"\";\n  position: absolute;\n  top: 0.3em;\n  left: 0px;\n  width: 100%;\n  border-top: 0.2em solid #fffefe;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9zY3NzL3N0eWxlcy5zY3NzIiwic3JjL2FwcC9hcHAuY29tcG9uZW50LnNjc3MiLCJzcmMvc2Nzcy9pbmNsdWRlcy9jb2xvcnMuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFDUSxnRUFBQTtBQUdSO0VBQ0kseUNBQUE7QUNGSjtBRElBO0VBQ0kseUJBQUE7RUFDQSxZQUFBO0VBQ0Esa0JBQUE7QUNESjtBREdBO0VBQ0ksb0JBQUE7RUFDQSxrQkFBQTtBQ0FKO0FERUE7RUFDSSxvQkFBQTtFQUNBLGlCQUFBO0VBQ0EsZ0JBQUE7RUFDQSxpQkFBQTtFQUNBLGlDQUFBO0FDQ0o7QURFQTtFQUdJLFNBQUE7RUFDQSxVQUFBO0VBQ0EsVUFBQTtFQUNBLFlBQUE7RUFDQSxnQkFBQTtFQUNBLHFCRTlCQztBRDZCTDtBREdBO0VBQ0ksZ0JBQUE7RUFBZ0IsZ0JBQUE7RUFBZ0IsbUJBQUE7QUNFcEM7QUFuQ0E7RUFDSSxrQkFBQTtFQUNBLFNBQUE7RUFDQSxRQUFBO0VBQ0EsV0FBQTtFQUNBLGFBQUE7RUFDQSxZQUFBO0VBQ0EseUJDVEM7QUQrQ0w7QUFwQ0E7RUFDSSxVQUFBO0FBdUNKO0FBckNBO0VBQ0ksVUFBQTtFQUNBLGdCQUFBO0VBQ0EsaUJBQUE7RUFDQSxZQUFBO0FBd0NKO0FBdENBO0VBQ0ksa0JBQUE7RUFDQSxVQUFBO0VBQ0EsaUJBQUE7RUFDQSxrQkFBQTtBQXlDSjtBQXZDQTtFQUNJLGtCQUFBO0VBQ0EsaUJBQUE7RUFDQSxTQUFBO0VBQ0EsY0FBQTtFQUNBLFdBQUE7RUFDQSx5QkM3QkM7QUR1RUw7QUF4Q0E7RUFDSTtJQUNJLGtCQUFBO0lBQ0EsU0FBQTtJQUNBLFFBQUE7SUFDQSxXQUFBO0lBQ0EsYUFBQTtJQUNBLFlBQUE7SUFDQSx5QkMxQ0g7RURxRkg7O0VBeENFO0lBQ0ksa0JBQUE7SUFDQSxTQUFBO0VBMkNOOztFQXhDRTtJQUNJLGtCQUFBO0lBQ0EsU0FBQTtJQUNBLGdCQUFBO0lBQ0EsaUJBQUE7RUEyQ047O0VBekNFO0lBQ0ksa0JBQUE7SUFDQSxVQUFBO0VBNENOOztFQXpDRTtJQUNJLGtCQUFBO0lBQ0EsU0FBQTtJQUNBLFdBQUE7SUFDQSxXQUFBO0VBNENOO0FBQ0Y7QUExQ0E7RUFDSSx1QkFBQTtFQUNBLFNBQUE7RUFDQSxhQUFBO0VBQ0EsV0FBQTtFQUNBLFVBQUE7RUFDQSxrQkFBQTtBQTRDSjtBQXhDQSw2QkFBQTtBQUNBO0VBRUksWUFBQTtFQUFjLHFCQUFBO0VBQ2QsUUFBQTtFQUFVLDBDQUFBO0VBQ1Ysa0JBQUE7RUFBb0Isa0JBQUE7RUFDcEIsWUFBQTtFQUFjLGdCQUFBO0VBQ2QsTUFBQTtFQUFRLG9CQUFBO0VBQ1IsT0FBQTtFQUNBLHlCQUFBO0VBQTJCLFNBQUE7RUFDM0Isa0JBQUE7RUFBb0IsOEJBQUE7RUFDcEIsaUJBQUE7RUFBbUIsb0NBQUE7RUFDbkIsZ0JBQUE7RUFBa0IseURBQUE7QUFtRHRCO0FBakRFLDhCQUFBO0FBQ0Y7RUFDSSx5QkFBQTtFQUNBLHFCQUFBO0VBQ0EsZUFBQTtFQUNBLFlBQUE7RUFDQSxjQUFBO0VBQ0EsZ0JBQUE7QUFvREo7QUFsREUsaUVBQUE7QUFDRjtFQUNJLGNBQUE7QUFxREo7QUFsREUsMkRBQUE7QUFDQTtFQUNFLGtCQUFBO0VBQ0EsTUFBQTtFQUNBLFdBQUE7RUFDQSxlQUFBO0VBQ0EsaUJBQUE7QUFxREo7QUFsREUsc0hBQUE7QUFDQTtFQUNFLDRCQUFBO0VBQ0EsYUFBQTtBQXFESjtBQWxERSxnSUFBQTtBQUNBO0VBQ0U7SUFBVSxpQkFBQTtFQXNEWjs7RUFyREU7SUFBWSxlQUFBO0VBeURkO0FBQ0Y7QUF4REU7RUFDSSxrQkFBQTtFQUNBLHFCQUFBO0VBQ0EsYUFBQTtFQUNBLGFBQUE7RUFDQSxtQkFBQTtFQUNBLDZCQUFBO0VBQ0Esa0NBQUE7QUEwRE47QUF4REU7RUFDRSxXQUFBO0VBQ0Esa0JBQUE7RUFDQSxVQUFBO0VBQ0EsU0FBQTtFQUNBLFdBQUE7RUFDQSwrQkFBQTtBQTJESiIsImZpbGUiOiJzcmMvYXBwL2FwcC5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIlxuQGltcG9ydCB1cmwoJ2h0dHBzOi8vZm9udHMuZ29vZ2xlYXBpcy5jb20vY3NzP2ZhbWlseT1PcGVuK1NhbnMnKTtcbkBpbXBvcnQgXCJpbmNsdWRlcy9jb2xvcnNcIjtcbiRvcGVuLXNhbnM6ICdPcGVuLVNhbnMnLCBzYW5zLXNlcmlmO1xuYm9keSB7XG4gICAgZm9udC1mYW1pbHk6IEFyaWFsLCBIZWx2ZXRpY2EsIHNhbnMtc2VyaWZcbn1cbmgxIHtcbiAgICB0ZXh0LXRyYW5zZm9ybTp1cHBlcmNhc2U7XG4gICAgY29sb3I6d2hpdGU7XG4gICAgdGV4dC1hbGlnbjpjZW50ZXI7XG59XG5oMyB7XG4gICAgdGV4dC10cmFuc2Zvcm06bm9uZTtcbiAgICB0ZXh0LWFsaWduOmNlbnRlcjtcbn1cbi5zZWFyY2gtYm94IHtcbiAgICBwYWRkaW5nLWJvdHRvbToyNHB4O1xuICAgIHBhZGRpbmctcmlnaHQ6NSU7XG4gICAgcGFkZGluZy1sZWZ0OjUlO1xuICAgIG1hcmdpbi1sZWZ0OjE2cHg7XG4gICAgYm94LXNoYWRvdzogMHB4IDVweCAxMnB4IDJweCBncmF5O1xuICAgIC8vIGJhY2tncm91bmQtY29sb3I6d2hpdGU7XG59XG4uc2VhcmNoLWJhciB7XG4gICAgLy8gbWFyZ2luLWxlZnQ6NTAlO1xuICAgIC8vIG1hcmdpbi1yaWdodDo1JTtcbiAgICBsZWZ0OjBweDtcbiAgICByaWdodDowcHg7XG4gICAgd2lkdGg6IDk1JTtcbiAgICBoZWlnaHQ6NTJweDtcbiAgICBtYXJnaW4tdG9wOjEycHg7XG4gICAgYm9yZGVyLWNvbG9yOiRjMDI7XG59XG4ucmVzdWx0cy1saXN0IHtcbiAgICBtYXJnaW4tbGVmdDoxMiU7cGFkZGluZy10b3A6NHB4O3BhZGRpbmctYm90dG9tOjRweDtcbn0iLCJAaW1wb3J0ICcuLi9zY3NzL3N0eWxlcyc7XG5AaW1wb3J0ICcuLi9zY3NzL2luY2x1ZGVzL2NvbG9ycy5zY3NzJztcbi5iYW5uZXIge1xuICAgIHBvc2l0aW9uOiBhYnNvbHV0ZTtcbiAgICBsZWZ0OiAwcHg7XG4gICAgdG9wOiAwcHg7XG4gICAgd2lkdGg6IDEwMCU7XG4gICAgaGVpZ2h0OiAzMjBweDtcbiAgICB6LWluZGV4OiAyODI7XG4gICAgYmFja2dyb3VuZC1jb2xvcjokYzAwO1xufVxuLnRpdGxlIHtcbiAgICB0b3A6MTAwcHg7XG59XG4uc3VidGl0bGUge1xuICAgIHRvcDoyMjBweDtcbiAgICBwYWRkaW5nLWxlZnQ6OCU7XG4gICAgcGFkZGluZy1yaWdodDo4JTtcbiAgICBjb2xvcjogd2hpdGU7XG59XG4ub3V0bGV0IHtcbiAgICBwb3NpdGlvbjpyZWxhdGl2ZTtcbiAgICB0b3A6MzIwcHg7XG4gICAgbWluLWhlaWdodDo4MDBweDtcbiAgICBtYXJnaW4tYm90dG9tOjE1JTtcbn1cbi5mb290ZXIge1xuICAgIHBvc2l0aW9uOmFic29sdXRlO1xuICAgIG1pbi1oZWlnaHQ6MTgwcHg7XG4gICAgbGVmdDowcHg7XG4gICAgYm90dG9tOi0xODBweDtcbiAgICB3aWR0aDoxMDAlO1xuICAgIGJhY2tncm91bmQtY29sb3I6JGMwMztcbn1cbkBtZWRpYSBzY3JlZW4gYW5kIChtYXgtd2lkdGg6OTI0cHgpIHtcbiAgICAuYmFubmVyIHtcbiAgICAgICAgcG9zaXRpb246IGFic29sdXRlO1xuICAgICAgICBsZWZ0OiAwcHg7XG4gICAgICAgIHRvcDogMHB4O1xuICAgICAgICB3aWR0aDogMTAwJTtcbiAgICAgICAgaGVpZ2h0OiAzMjBweDtcbiAgICAgICAgei1pbmRleDogMjgyO1xuICAgICAgICBiYWNrZ3JvdW5kLWNvbG9yOiRjMDA7XG5cbiAgICB9XG4gICAgLnRpdGxlIHtcbiAgICAgICAgcG9zaXRpb246cmVsYXRpdmU7XG4gICAgICAgIHRvcDo0MHB4O1xuXG4gICAgfVxuICAgIC5zdWJ0aXRsZSB7XG4gICAgICAgIHBvc2l0aW9uOnJlbGF0aXZlO1xuICAgICAgICB0b3A6IDU0cHg7XG4gICAgICAgIHBhZGRpbmctbGVmdDo4JTtcbiAgICAgICAgcGFkZGluZy1yaWdodDo4JTtcbiAgICB9XG4gICAgLm91dGxldCB7XG4gICAgICAgIHBvc2l0aW9uOnJlbGF0aXZlO1xuICAgICAgICB0b3A6MzIwcHg7XG5cbiAgICB9XG4gICAgLmZvb3RlciB7XG4gICAgICAgIHBvc2l0aW9uOmFic29sdXRlO1xuICAgICAgICBsZWZ0OjBweDtcbiAgICAgICAgYm90dG9tOjBweDtcbiAgICAgICAgd2lkdGg6MTAwJTtcbiAgICB9XG59XG4uc2VhcmNoIHtcbiAgICBiYWNrZ3JvdW5kLWNvbG9yOmdyZWVuO1xuICAgIGxlZnQ6IDBweDtcbiAgICBoZWlnaHQ6NDgwcHg7XG4gICAgd2lkdGg6MTAwJTtcbiAgICB0b3A6NDgwcHg7XG4gICAgcG9zaXRpb246YWJzb2x1dGU7ICBcblxufVxuXG4vKiBUaGUgc2lkZSBuYXZpZ2F0aW9uIG1lbnUgKi9cbi5zaWRlbmF2IHtcblxuICAgIGhlaWdodDogMTAwJTsgLyogMTAwJSBGdWxsLWhlaWdodCAqL1xuICAgIHdpZHRoOiAwOyAvKiAwIHdpZHRoIC0gY2hhbmdlIHRoaXMgd2l0aCBKYXZhU2NyaXB0ICovXG4gICAgcG9zaXRpb246IGFic29sdXRlOyAvKiBTdGF5IGluIHBsYWNlICovXG4gICAgei1pbmRleDogNDAwOyAvKiBTdGF5IG9uIHRvcCAqL1xuICAgIHRvcDogMDsgLyogU3RheSBhdCB0aGUgdG9wICovXG4gICAgbGVmdDogMDtcbiAgICBiYWNrZ3JvdW5kLWNvbG9yOiAjODE4MTgxOyAvKiBCbGFjayovXG4gICAgb3ZlcmZsb3cteDogaGlkZGVuOyAvKiBEaXNhYmxlIGhvcml6b250YWwgc2Nyb2xsICovXG4gICAgcGFkZGluZy10b3A6IDYwcHg7IC8qIFBsYWNlIGNvbnRlbnQgNjBweCBmcm9tIHRoZSB0b3AgKi9cbiAgICB0cmFuc2l0aW9uOiAwLjVzOyAvKiAwLjUgc2Vjb25kIHRyYW5zaXRpb24gZWZmZWN0IHRvIHNsaWRlIGluIHRoZSBzaWRlbmF2ICovXG4gIH1cbiAgLyogVGhlIG5hdmlnYXRpb24gbWVudSBsaW5rcyAqL1xuLnNpZGVuYXYgYSB7XG4gICAgcGFkZGluZzogOHB4IDhweCA4cHggMzJweDtcbiAgICB0ZXh0LWRlY29yYXRpb246IG5vbmU7XG4gICAgZm9udC1zaXplOiAyNXB4O1xuICAgIGNvbG9yOiB3aGl0ZTtcbiAgICBkaXNwbGF5OiBibG9jaztcbiAgICB0cmFuc2l0aW9uOiAwLjNzO1xuICB9XG4gIC8qIFdoZW4geW91IG1vdXNlIG92ZXIgdGhlIG5hdmlnYXRpb24gbGlua3MsIGNoYW5nZSB0aGVpciBjb2xvciAqL1xuLnNpZGVuYXYgYTpob3ZlciB7XG4gICAgY29sb3I6ICNmMWYxZjE7XG4gIH1cbiAgXG4gIC8qIFBvc2l0aW9uIGFuZCBzdHlsZSB0aGUgY2xvc2UgYnV0dG9uICh0b3AgcmlnaHQgY29ybmVyKSAqL1xuICAuc2lkZW5hdiAuY2xvc2VidG4ge1xuICAgIHBvc2l0aW9uOiBhYnNvbHV0ZTtcbiAgICB0b3A6IDA7XG4gICAgcmlnaHQ6IDI1cHg7XG4gICAgZm9udC1zaXplOiAzNnB4O1xuICAgIG1hcmdpbi1sZWZ0OiA1MHB4O1xuICB9XG4gIFxuICAvKiBTdHlsZSBwYWdlIGNvbnRlbnQgLSB1c2UgdGhpcyBpZiB5b3Ugd2FudCB0byBwdXNoIHRoZSBwYWdlIGNvbnRlbnQgdG8gdGhlIHJpZ2h0IHdoZW4geW91IG9wZW4gdGhlIHNpZGUgbmF2aWdhdGlvbiAqL1xuICAjbWFpbiB7XG4gICAgdHJhbnNpdGlvbjogbWFyZ2luLWxlZnQgLjVzO1xuICAgIHBhZGRpbmc6IDIwcHg7XG4gIH1cbiAgXG4gIC8qIE9uIHNtYWxsZXIgc2NyZWVucywgd2hlcmUgaGVpZ2h0IGlzIGxlc3MgdGhhbiA0NTBweCwgY2hhbmdlIHRoZSBzdHlsZSBvZiB0aGUgc2lkZW5hdiAobGVzcyBwYWRkaW5nIGFuZCBhIHNtYWxsZXIgZm9udCBzaXplKSAqL1xuICBAbWVkaWEgc2NyZWVuIGFuZCAobWF4LWhlaWdodDogNDUwcHgpIHtcbiAgICAuc2lkZW5hdiB7cGFkZGluZy10b3A6IDE1cHg7fVxuICAgIC5zaWRlbmF2IGEge2ZvbnQtc2l6ZTogMThweDt9XG4gIH0gICAgXG4gIC5oYW1idXJnZXIge1xuICAgICAgcG9zaXRpb246cmVsYXRpdmU7XG4gICAgICBkaXNwbGF5OmlubGluZS1ibG9jaztcbiAgICAgIHdpZHRoOjEuMjVlbTtcbiAgICAgIGhlaWdodDogMC44ZW07XG4gICAgICBtYXJnaW4tcmlnaHQ6MC4zZW07XG4gICAgICBib3JkZXItdG9wOiAwLjJlbSBzb2xpZCByZ2IoMjU1LCAyNTUsIDI1NSk7XG4gICAgICBib3JkZXItYm90dG9tOiAwLjJlbSBzb2xpZCByZ2IoMjU1LCAyNTQsIDI1NCk7XG4gIH0gXG4gIC5oYW1idXJnZXI6YmVmb3JlIHtcbiAgICBjb250ZW50OiBcIlwiO1xuICAgIHBvc2l0aW9uOiBhYnNvbHV0ZTtcbiAgICB0b3A6IDAuM2VtO1xuICAgIGxlZnQ6IDBweDtcbiAgICB3aWR0aDogMTAwJTtcbiAgICBib3JkZXItdG9wOiAwLjJlbSBzb2xpZCByZ2IoMjU1LCAyNTQsIDI1NCk7XG59XG4iLCIkYzAwOiMwNTEyNTM7XG4kYzAxOndoaXRlO1xuJGMwMjojOTY5Njk2O1xuJGMwMzojNjM2MzYzO1xuJGMwNDojNTM1MzUzOyJdfQ== */"] });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](AppComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
                selector: 'app-root-paddle',
                templateUrl: './app.component.html',
                styleUrls: ['./app.component.scss'],
                providers: []
            }]
    }], function () { return [{ type: _auth_auth_service__WEBPACK_IMPORTED_MODULE_1__["AuthService"] }]; }, null); })();


/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/__ivy_ngcc__/fesm2015/platform-browser.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/__ivy_ngcc__/fesm2015/forms.js");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
/* harmony import */ var _services_river_data_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./services/river-data.service */ "./src/app/services/river-data.service.ts");
/* harmony import */ var _services_river_user_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./services/river-user.service */ "./src/app/services/river-user.service.ts");
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./app-routing.module */ "./src/app/app-routing.module.ts");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");
/* harmony import */ var _angular_service_worker__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/service-worker */ "./node_modules/@angular/service-worker/__ivy_ngcc__/fesm2015/service-worker.js");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../environments/environment */ "./src/environments/environment.ts");
/* harmony import */ var _profile_profile_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./profile/profile.component */ "./src/app/profile/profile.component.ts");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm2015/index.js");
/* harmony import */ var _river_list_river_list_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./river-list/river-list.component */ "./src/app/river-list/river-list.component.ts");
/* harmony import */ var _river_detail_river_detail_component__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./river-detail/river-detail.component */ "./src/app/river-detail/river-detail.component.ts");
/* harmony import */ var _favorites_favorites_component__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! ./favorites/favorites.component */ "./src/app/favorites/favorites.component.ts");

















class AppModule {
}
AppModule.ɵmod = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineNgModule"]({ type: AppModule, bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_3__["AppComponent"]] });
AppModule.ɵinj = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineInjector"]({ factory: function AppModule_Factory(t) { return new (t || AppModule)(); }, providers: [_services_river_data_service__WEBPACK_IMPORTED_MODULE_4__["RiverDataService"], _services_river_user_service__WEBPACK_IMPORTED_MODULE_5__["RiverUserSerice"]], imports: [[
            _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"],
            _app_routing_module__WEBPACK_IMPORTED_MODULE_6__["AppRoutingModule"],
            _angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpClientModule"],
            _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormsModule"],
            _angular_service_worker__WEBPACK_IMPORTED_MODULE_8__["ServiceWorkerModule"].register('ngsw-worker.js', { enabled: _environments_environment__WEBPACK_IMPORTED_MODULE_9__["environment"].production })
        ]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵsetNgModuleScope"](AppModule, { declarations: [_app_component__WEBPACK_IMPORTED_MODULE_3__["AppComponent"], _river_list_river_list_component__WEBPACK_IMPORTED_MODULE_12__["RiverListComponent"], _river_detail_river_detail_component__WEBPACK_IMPORTED_MODULE_13__["RiverDetailComponent"], _favorites_favorites_component__WEBPACK_IMPORTED_MODULE_14__["FavoritesComponent"], _profile_profile_component__WEBPACK_IMPORTED_MODULE_10__["ProfileComponent"]], imports: [_angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"],
        _app_routing_module__WEBPACK_IMPORTED_MODULE_6__["AppRoutingModule"],
        _angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpClientModule"],
        _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormsModule"], _angular_service_worker__WEBPACK_IMPORTED_MODULE_8__["ServiceWorkerModule"]] }); })();
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵsetClassMetadata"](AppModule, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"],
        args: [{
                declarations: [
                    _app_component__WEBPACK_IMPORTED_MODULE_3__["AppComponent"],
                    _app_routing_module__WEBPACK_IMPORTED_MODULE_6__["routableComponents"],
                    _profile_profile_component__WEBPACK_IMPORTED_MODULE_10__["ProfileComponent"]
                ],
                imports: [
                    _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"],
                    _app_routing_module__WEBPACK_IMPORTED_MODULE_6__["AppRoutingModule"],
                    _angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpClientModule"],
                    _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormsModule"],
                    _angular_service_worker__WEBPACK_IMPORTED_MODULE_8__["ServiceWorkerModule"].register('ngsw-worker.js', { enabled: _environments_environment__WEBPACK_IMPORTED_MODULE_9__["environment"].production })
                ],
                providers: [_services_river_data_service__WEBPACK_IMPORTED_MODULE_4__["RiverDataService"], _services_river_user_service__WEBPACK_IMPORTED_MODULE_5__["RiverUserSerice"]],
                bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_3__["AppComponent"]]
            }]
    }], null, null); })();


/***/ }),

/***/ "./src/app/auth/auth.service.ts":
/*!**************************************!*\
  !*** ./src/app/auth/auth.service.ts ***!
  \**************************************/
/*! exports provided: AuthService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AuthService", function() { return AuthService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _auth0_auth0_spa_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @auth0/auth0-spa-js */ "./node_modules/@auth0/auth0-spa-js/dist/auth0-spa-js.production.esm.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm2015/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm2015/operators/index.js");
/* harmony import */ var src_environments_environment__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/environments/environment */ "./src/environments/environment.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");







class AuthService {
    constructor(router) {
        this.router = router;
        // Create a local property for login status
        this.loggedIn = null;
        // Create an observable of Auth0 instance of client
        this.auth0Client$ = Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["from"])(Object(_auth0_auth0_spa_js__WEBPACK_IMPORTED_MODULE_1__["default"])({
            domain: src_environments_environment__WEBPACK_IMPORTED_MODULE_4__["environment"].auth0Domain,
            client_id: src_environments_environment__WEBPACK_IMPORTED_MODULE_4__["environment"].auth0ClientId,
            redirect_uri: src_environments_environment__WEBPACK_IMPORTED_MODULE_4__["environment"].baseUrl + "/callback",
            scope: src_environments_environment__WEBPACK_IMPORTED_MODULE_4__["environment"].openIdScope
        })).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["shareReplay"])(1), // Every subscription receives the same shared value
        Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(err => Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(err)));
        // Define observables for SDK methods that return promises by default
        // For each Auth0 SDK method, first ensure the client instance is ready
        // concatMap: Using the client instance, call SDK method; SDK returns a promise
        // from: Convert that resulting promise into an observable
        this.isAuthenticated$ = this.auth0Client$.pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["concatMap"])((client) => Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["from"])(client.isAuthenticated())), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["tap"])(res => this.loggedIn = res));
        this.handleRedirectCallback$ = this.auth0Client$.pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["concatMap"])((client) => Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["from"])(client.handleRedirectCallback())));
        // Create subject and public observable of user profile data
        this.userProfileSubject$ = new rxjs__WEBPACK_IMPORTED_MODULE_2__["BehaviorSubject"](null);
        this.userProfile$ = this.userProfileSubject$.asObservable();
        // On initial load, check authentication state with authorization server
        // Set up local auth streams if user is already authenticated
        this.localAuthSetup();
        // Handle redirect from Auth0 login
        this.handleAuthCallback();
    }
    // When calling, options can be passed if desired
    // https://auth0.github.io/auth0-spa-js/classes/auth0client.html#getuser
    getUser$(options) {
        return this.auth0Client$.pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["concatMap"])((client) => Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["from"])(client.getUser(options))), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["tap"])(user => this.userProfileSubject$.next(user)));
    }
    localAuthSetup() {
        // This should only be called on app initialization
        // Set up local authentication streams
        const checkAuth$ = this.isAuthenticated$.pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["concatMap"])((loggedIn) => {
            if (loggedIn) {
                // If authenticated, get user and set in app
                // NOTE: you could pass options here if needed
                return this.getUser$();
            }
            // If not authenticated, return stream that emits 'false'
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(loggedIn);
        }));
        checkAuth$.subscribe();
    }
    login(redirectPath = '/') {
        // A desired redirect path can be passed to login method
        // (e.g., from a route guard)
        // Ensure Auth0 client instance exists
        this.auth0Client$.subscribe((client) => {
            // Call method to log in
            client.loginWithRedirect({
                redirect_uri: src_environments_environment__WEBPACK_IMPORTED_MODULE_4__["environment"].baseUrl + "/callback",
                appState: { target: redirectPath }
            });
        });
    }
    handleAuthCallback() {
        // Call when app reloads after user logs in with Auth0
        const params = window.location.search;
        if (params.includes('code=') && params.includes('state=')) {
            let targetRoute; // Path to redirect to after login processsed
            const authComplete$ = this.handleRedirectCallback$.pipe(
            // Have client, now call method to handle auth callback redirect
            Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["tap"])(cbRes => {
                // Get and set target redirect route from callback results
                targetRoute = cbRes.appState && cbRes.appState.target ? cbRes.appState.target : '/';
            }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["concatMap"])(() => {
                // Redirect callback complete; get user and login status
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["combineLatest"])([
                    this.getUser$(),
                    this.isAuthenticated$
                ]);
            }));
            // Subscribe to authentication completion observable
            // Response will be an array of user and login status
            authComplete$.subscribe(([user, loggedIn]) => {
                // Redirect to target route after callback processing
                this.router.navigate([targetRoute]);
            });
        }
    }
    logout() {
        // Ensure Auth0 client instance exists
        this.auth0Client$.subscribe((client) => {
            // Call method to log out
            client.logout({
                client_id: src_environments_environment__WEBPACK_IMPORTED_MODULE_4__["environment"].auth0ClientId,
                returnTo: `${window.location.origin}`
            });
        });
    }
}
AuthService.ɵfac = function AuthService_Factory(t) { return new (t || AuthService)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_angular_router__WEBPACK_IMPORTED_MODULE_5__["Router"])); };
AuthService.ɵprov = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({ token: AuthService, factory: AuthService.ɵfac, providedIn: 'root' });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](AuthService, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"],
        args: [{
                providedIn: 'root'
            }]
    }], function () { return [{ type: _angular_router__WEBPACK_IMPORTED_MODULE_5__["Router"] }]; }, null); })();


/***/ }),

/***/ "./src/app/favorites/favorites.component.ts":
/*!**************************************************!*\
  !*** ./src/app/favorites/favorites.component.ts ***!
  \**************************************************/
/*! exports provided: FavoritesComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FavoritesComponent", function() { return FavoritesComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");


class FavoritesComponent {
    ngOnInit() {
        console.log(history.state.data);
    }
}
FavoritesComponent.ɵfac = function FavoritesComponent_Factory(t) { return new (t || FavoritesComponent)(); };
FavoritesComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({ type: FavoritesComponent, selectors: [["app-favorites"]], decls: 2, vars: 0, consts: [[1, "outlet"]], template: function FavoritesComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, " COMING SOON\n");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    } }, encapsulation: 2 });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](FavoritesComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
                selector: 'app-favorites',
                templateUrl: 'favorites.component.html',
                styleUrls: []
            }]
    }], null, null); })();


/***/ }),

/***/ "./src/app/model/riveruserreference.ts":
/*!*********************************************!*\
  !*** ./src/app/model/riveruserreference.ts ***!
  \*********************************************/
/*! exports provided: RiverUserPreference */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RiverUserPreference", function() { return RiverUserPreference; });
class RiverUserPreference {
}


/***/ }),

/***/ "./src/app/profile/profile.component.ts":
/*!**********************************************!*\
  !*** ./src/app/profile/profile.component.ts ***!
  \**********************************************/
/*! exports provided: ProfileComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ProfileComponent", function() { return ProfileComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _auth_auth_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../auth/auth.service */ "./src/app/auth/auth.service.ts");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");




function ProfileComponent_pre_0_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "pre");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "code");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpipe"](3, "json");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](4, "\n");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} if (rf & 2) {
    const profile_r1 = ctx.ngIf;
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate"](_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpipeBind1"](3, 1, profile_r1));
} }
class ProfileComponent {
    constructor(auth) {
        this.auth = auth;
    }
    ngOnInit() {
    }
}
ProfileComponent.ɵfac = function ProfileComponent_Factory(t) { return new (t || ProfileComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_auth_auth_service__WEBPACK_IMPORTED_MODULE_1__["AuthService"])); };
ProfileComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({ type: ProfileComponent, selectors: [["app-profile"]], decls: 2, vars: 3, consts: [[4, "ngIf"]], template: function ProfileComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](0, ProfileComponent_pre_0_Template, 5, 3, "pre", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpipe"](1, "async");
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpipeBind1"](1, 1, ctx.auth.userProfile$));
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_2__["NgIf"]], pipes: [_angular_common__WEBPACK_IMPORTED_MODULE_2__["AsyncPipe"], _angular_common__WEBPACK_IMPORTED_MODULE_2__["JsonPipe"]], styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3Byb2ZpbGUvcHJvZmlsZS5jb21wb25lbnQuc2NzcyJ9 */"] });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](ProfileComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
                selector: 'app-profile',
                templateUrl: './profile.component.html',
                styleUrls: ['./profile.component.scss']
            }]
    }], function () { return [{ type: _auth_auth_service__WEBPACK_IMPORTED_MODULE_1__["AuthService"] }]; }, null); })();


/***/ }),

/***/ "./src/app/river-detail/river-detail.component.ts":
/*!********************************************************!*\
  !*** ./src/app/river-detail/river-detail.component.ts ***!
  \********************************************************/
/*! exports provided: RiverDetailComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RiverDetailComponent", function() { return RiverDetailComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _model_riveruserreference__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../model/riveruserreference */ "./src/app/model/riveruserreference.ts");
/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! lodash */ "./node_modules/lodash/lodash.js");
/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(lodash__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");
/* harmony import */ var _services_river_data_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../services/river-data.service */ "./src/app/services/river-data.service.ts");
/* harmony import */ var _services_river_user_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../services/river-user.service */ "./src/app/services/river-user.service.ts");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");








function RiverDetailComponent_h3_3_Template(rf, ctx) { if (rf & 1) {
    const _r6 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "h3", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "button", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵlistener"]("click", function RiverDetailComponent_h3_3_Template_button_click_2_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵrestoreView"](_r6); const ctx_r5 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵnextContext"](); return ctx_r5.saveRiverAsFavorite(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](3, "Add To Favorites");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate1"](" ", ctx_r0.river.name, " ");
} }
function RiverDetailComponent_span_5_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "span");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate1"]("location: ", ctx_r1.river.latitude, "");
} }
function RiverDetailComponent_span_6_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "span");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, ",\u00A0");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} }
function RiverDetailComponent_span_7_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "span");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate"](ctx_r3.river.longitude);
} }
function RiverDetailComponent_table_8_tr_10_span_5_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "span");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "cf/s");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} }
function RiverDetailComponent_table_8_tr_10_span_8_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "span");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "ft");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} }
function RiverDetailComponent_table_8_tr_10_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "tr");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](3, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](5, RiverDetailComponent_table_8_tr_10_span_5_Template, 2, 0, "span", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](6, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](7);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](8, RiverDetailComponent_table_8_tr_10_span_8_Template, 2, 0, "span", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} if (rf & 2) {
    const data_r8 = ctx.$implicit;
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate"](data_r8.dateTime);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate1"]("", data_r8.flow, " ");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", data_r8.flow);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate1"]("", data_r8.level, " ");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", data_r8.level);
} }
function RiverDetailComponent_table_8_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "table", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "thead");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "tr");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](3, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](4, "Date");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](5, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](6, "Flow");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](7, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](8, "Level");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](9, "tbody");
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](10, RiverDetailComponent_table_8_tr_10_Template, 9, 5, "tr", 7);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r4 = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](10);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngForOf", ctx_r4.river.riverData);
} }
class RiverDetailComponent {
    constructor(route, riverData, riverUser) {
        this.route = route;
        this.riverData = riverData;
        this.riverUser = riverUser;
        this.pullRiverDetails = (riverCode) => {
            let thisRiver;
            this.riverData.getRiverDetails(riverCode).then((data) => {
                thisRiver = data;
                const vals = lodash__WEBPACK_IMPORTED_MODULE_2__["each"](thisRiver.riverData, (r) => {
                    r.dateTime = new Date(r.dateTime);
                });
                const vals2 = lodash__WEBPACK_IMPORTED_MODULE_2__["orderBy"](thisRiver.riverData, ['dateTime'], ['desc']);
                thisRiver.riverData = vals2;
                this.river = thisRiver;
            });
            return thisRiver;
        };
        this.saveRiverAsFavorite = () => {
            let user = this.riverUser.getActiveUser();
            if (!user) {
                alert("please log in");
            }
            else {
                const pref = new _model_riveruserreference__WEBPACK_IMPORTED_MODULE_1__["RiverUserPreference"]();
                pref.sub = user.sub;
                pref.riverName = this.river.name;
                pref.riverId = this.river.riverId;
                pref.lastFlow = this.river.riverData[0].flow;
                pref.lastLevel = this.river.riverData[0].level;
                pref.lastReported = this.river.riverData[0].dateTime;
                this.riverUser.postUserFavorite(pref).then((data) => {
                    console.log(data);
                });
            }
        };
    }
    ngOnInit() {
        this.riverCode = this.route.snapshot.params['id'];
        this.point = this.route.snapshot.queryParams;
        this.pullRiverDetails(this.riverCode);
    }
    ngOnDestroy() {
        //TODO
    }
    getLatitude() {
        return this.river.latitude;
    }
}
RiverDetailComponent.ɵfac = function RiverDetailComponent_Factory(t) { return new (t || RiverDetailComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_3__["ActivatedRoute"]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_services_river_data_service__WEBPACK_IMPORTED_MODULE_4__["RiverDataService"]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_services_river_user_service__WEBPACK_IMPORTED_MODULE_5__["RiverUserSerice"])); };
RiverDetailComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({ type: RiverDetailComponent, selectors: [["app-river-detail"]], decls: 9, vars: 5, consts: [[1, "outlet"], ["class", "", 4, "ngIf"], [4, "ngIf"], ["style", "left:0px;right:0px;", 4, "ngIf"], [1, ""], [3, "click"], [2, "left", "0px", "right", "0px"], [4, "ngFor", "ngForOf"]], template: function RiverDetailComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "div");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "div");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](3, RiverDetailComponent_h3_3_Template, 4, 1, "h3", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](4, "h3");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](5, RiverDetailComponent_span_5_Template, 2, 1, "span", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](6, RiverDetailComponent_span_6_Template, 2, 0, "span", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](7, RiverDetailComponent_span_7_Template, 2, 1, "span", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](8, RiverDetailComponent_table_8_Template, 11, 1, "table", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](3);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", ctx.river);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", ctx.river && ctx.river.latitude);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", ctx.river && ctx.river.latitude && ctx.river.longitude);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", ctx.river);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngIf", ctx.river);
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_6__["NgIf"], _angular_common__WEBPACK_IMPORTED_MODULE_6__["NgForOf"]], styles: ["@charset \"UTF-8\";\n.favorite[_ngcontent-%COMP%] {\n  cursor: pointer;\n}\n.favorite[_ngcontent-%COMP%]:hover {\n  content: \"\u2605\";\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvcml2ZXItZGV0YWlsL3JpdmVyLWRldGFpbC5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQSxnQkFBZ0I7QUFBaEI7RUFDSSxlQUFBO0FBRUo7QUFDQTtFQUNJLFlBQUE7QUFFSiIsImZpbGUiOiJzcmMvYXBwL3JpdmVyLWRldGFpbC9yaXZlci1kZXRhaWwuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIuZmF2b3JpdGUge1xuICAgIGN1cnNvcjpwb2ludGVyO1xufVxuXG4uZmF2b3JpdGU6aG92ZXIge1xuICAgIGNvbnRlbnQ6ICdcXDI2MDUnO1xuICAgIFxufSJdfQ== */"] });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](RiverDetailComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
                selector: 'app-river-detail',
                templateUrl: 'river-detail.component.html',
                styleUrls: ['river-detail.component.scss']
            }]
    }], function () { return [{ type: _angular_router__WEBPACK_IMPORTED_MODULE_3__["ActivatedRoute"] }, { type: _services_river_data_service__WEBPACK_IMPORTED_MODULE_4__["RiverDataService"] }, { type: _services_river_user_service__WEBPACK_IMPORTED_MODULE_5__["RiverUserSerice"] }]; }, null); })();


/***/ }),

/***/ "./src/app/river-list/river-list.component.ts":
/*!****************************************************!*\
  !*** ./src/app/river-list/river-list.component.ts ***!
  \****************************************************/
/*! exports provided: RiverListComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RiverListComponent", function() { return RiverListComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _services_river_data_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../services/river-data.service */ "./src/app/services/river-data.service.ts");
/* harmony import */ var _auth_auth_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../auth/auth.service */ "./src/app/auth/auth.service.ts");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/__ivy_ngcc__/fesm2015/forms.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/common.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");







const _c0 = function (a1) { return ["river", a1]; };
const _c1 = function (a0, a1) { return { "lat": a0, "long": a1 }; };
function RiverListComponent_div_4_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "span", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
} if (rf & 2) {
    const river_r1 = ctx.$implicit;
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction1"](3, _c0, river_r1.riverId))("queryParams", _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵpureFunction2"](5, _c1, river_r1.latitude, river_r1.longitude));
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtextInterpolate1"](" ", river_r1.name.toUpperCase(), " ");
} }
class RiverListComponent {
    constructor(riverData, auth) {
        this.riverData = riverData;
        this.auth = auth;
        this.searchValue = '';
        this.findRivers = (value) => {
            if (value.keyCode in [8, 46]) {
            }
            else {
                const search = this.searchValue;
                this.riverData.getAllUSRivers(search).then((response) => {
                    this.rivers = response;
                });
            }
        };
    }
}
RiverListComponent.ɵfac = function RiverListComponent_Factory(t) { return new (t || RiverListComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_services_river_data_service__WEBPACK_IMPORTED_MODULE_1__["RiverDataService"]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdirectiveInject"](_auth_auth_service__WEBPACK_IMPORTED_MODULE_2__["AuthService"])); };
RiverListComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({ type: RiverListComponent, selectors: [["app-river-list"]], decls: 5, vars: 2, consts: [[1, "river-search"], ["id", "riverSearch", "type", "text", 1, "search-bar", 3, "ngModel", "ngModelChange", "keyup"], [1, "river-list"], ["class", "river-list-data", 4, "ngFor", "ngForOf"], [1, "river-list-data"], [1, "river-search-result", 3, "routerLink", "queryParams"]], template: function RiverListComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "div", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](1, "div");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](2, "input", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵlistener"]("ngModelChange", function RiverListComponent_Template_input_ngModelChange_2_listener($event) { return ctx.searchValue = $event; })("keyup", function RiverListComponent_Template_input_keyup_2_listener($event) { return ctx.findRivers($event); });
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](3, "div", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtemplate"](4, RiverListComponent_div_4_Template, 3, 8, "div", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngModel", ctx.searchValue);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵadvance"](2);
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵproperty"]("ngForOf", ctx.rivers);
    } }, directives: [_angular_forms__WEBPACK_IMPORTED_MODULE_3__["DefaultValueAccessor"], _angular_forms__WEBPACK_IMPORTED_MODULE_3__["NgControlStatus"], _angular_forms__WEBPACK_IMPORTED_MODULE_3__["NgModel"], _angular_common__WEBPACK_IMPORTED_MODULE_4__["NgForOf"], _angular_router__WEBPACK_IMPORTED_MODULE_5__["RouterLink"]], styles: ["@import url(\"https://fonts.googleapis.com/css?family=Open+Sans\");\nbody[_ngcontent-%COMP%] {\n  font-family: Arial, Helvetica, sans-serif;\n}\nh1[_ngcontent-%COMP%] {\n  text-transform: uppercase;\n  color: white;\n  text-align: center;\n}\nh3[_ngcontent-%COMP%] {\n  text-transform: none;\n  text-align: center;\n}\n.search-box[_ngcontent-%COMP%] {\n  padding-bottom: 24px;\n  padding-right: 5%;\n  padding-left: 5%;\n  margin-left: 16px;\n  box-shadow: 0px 5px 12px 2px gray;\n}\n.search-bar[_ngcontent-%COMP%] {\n  left: 0px;\n  right: 0px;\n  width: 95%;\n  height: 52px;\n  margin-top: 12px;\n  border-color: #969696;\n}\n.results-list[_ngcontent-%COMP%] {\n  margin-left: 12%;\n  padding-top: 4px;\n  padding-bottom: 4px;\n}\n.river-search[_ngcontent-%COMP%] {\n  padding-left: 16%;\n  padding-right: 16%;\n  padding-bottom: 16px;\n}\n.river-list[_ngcontent-%COMP%] {\n  padding-left: 16%;\n  column-count: 2;\n}\n@media screen and (max-width: 924px) {\n  .river-list[_ngcontent-%COMP%] {\n    padding-left: 16%;\n    column-count: 1;\n  }\n}\n.river-list-data[_ngcontent-%COMP%] {\n  padding: 8px 8px 8px 0px;\n}\n.river-search-result[_ngcontent-%COMP%] {\n  color: #535353;\n  cursor: pointer;\n  font-weight: bold;\n}\n.river-search-result[_ngcontent-%COMP%]:hover {\n  color: #969696;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9zY3NzL3N0eWxlcy5zY3NzIiwic3JjL2FwcC9yaXZlci1saXN0L3JpdmVyLWxpc3QuY29tcG9uZW50LnNjc3MiLCJzcmMvc2Nzcy9pbmNsdWRlcy9jb2xvcnMuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFDUSxnRUFBQTtBQUdSO0VBQ0kseUNBQUE7QUNGSjtBRElBO0VBQ0kseUJBQUE7RUFDQSxZQUFBO0VBQ0Esa0JBQUE7QUNESjtBREdBO0VBQ0ksb0JBQUE7RUFDQSxrQkFBQTtBQ0FKO0FERUE7RUFDSSxvQkFBQTtFQUNBLGlCQUFBO0VBQ0EsZ0JBQUE7RUFDQSxpQkFBQTtFQUNBLGlDQUFBO0FDQ0o7QURFQTtFQUdJLFNBQUE7RUFDQSxVQUFBO0VBQ0EsVUFBQTtFQUNBLFlBQUE7RUFDQSxnQkFBQTtFQUNBLHFCRTlCQztBRDZCTDtBREdBO0VBQ0ksZ0JBQUE7RUFBZ0IsZ0JBQUE7RUFBZ0IsbUJBQUE7QUNFcEM7QUFsQ0E7RUFDSSxpQkFBQTtFQUNBLGtCQUFBO0VBQ0Esb0JBQUE7QUFxQ0o7QUFsQ0E7RUFDSSxpQkFBQTtFQUNBLGVBQUE7QUFxQ0o7QUFuQ0E7RUFDSTtJQUNJLGlCQUFBO0lBQ0EsZUFBQTtFQXNDTjtBQUNGO0FBbkNBO0VBQ0ksd0JBQUE7QUFxQ0o7QUFuQ0E7RUFDSSxjQ3BCQztFRHFCRCxlQUFBO0VBQ0EsaUJBQUE7QUFzQ0o7QUFuQ0E7RUFDSSxjQzVCQztBRGtFTCIsImZpbGUiOiJzcmMvYXBwL3JpdmVyLWxpc3Qvcml2ZXItbGlzdC5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIlxuQGltcG9ydCB1cmwoJ2h0dHBzOi8vZm9udHMuZ29vZ2xlYXBpcy5jb20vY3NzP2ZhbWlseT1PcGVuK1NhbnMnKTtcbkBpbXBvcnQgXCJpbmNsdWRlcy9jb2xvcnNcIjtcbiRvcGVuLXNhbnM6ICdPcGVuLVNhbnMnLCBzYW5zLXNlcmlmO1xuYm9keSB7XG4gICAgZm9udC1mYW1pbHk6IEFyaWFsLCBIZWx2ZXRpY2EsIHNhbnMtc2VyaWZcbn1cbmgxIHtcbiAgICB0ZXh0LXRyYW5zZm9ybTp1cHBlcmNhc2U7XG4gICAgY29sb3I6d2hpdGU7XG4gICAgdGV4dC1hbGlnbjpjZW50ZXI7XG59XG5oMyB7XG4gICAgdGV4dC10cmFuc2Zvcm06bm9uZTtcbiAgICB0ZXh0LWFsaWduOmNlbnRlcjtcbn1cbi5zZWFyY2gtYm94IHtcbiAgICBwYWRkaW5nLWJvdHRvbToyNHB4O1xuICAgIHBhZGRpbmctcmlnaHQ6NSU7XG4gICAgcGFkZGluZy1sZWZ0OjUlO1xuICAgIG1hcmdpbi1sZWZ0OjE2cHg7XG4gICAgYm94LXNoYWRvdzogMHB4IDVweCAxMnB4IDJweCBncmF5O1xuICAgIC8vIGJhY2tncm91bmQtY29sb3I6d2hpdGU7XG59XG4uc2VhcmNoLWJhciB7XG4gICAgLy8gbWFyZ2luLWxlZnQ6NTAlO1xuICAgIC8vIG1hcmdpbi1yaWdodDo1JTtcbiAgICBsZWZ0OjBweDtcbiAgICByaWdodDowcHg7XG4gICAgd2lkdGg6IDk1JTtcbiAgICBoZWlnaHQ6NTJweDtcbiAgICBtYXJnaW4tdG9wOjEycHg7XG4gICAgYm9yZGVyLWNvbG9yOiRjMDI7XG59XG4ucmVzdWx0cy1saXN0IHtcbiAgICBtYXJnaW4tbGVmdDoxMiU7cGFkZGluZy10b3A6NHB4O3BhZGRpbmctYm90dG9tOjRweDtcbn0iLCJAaW1wb3J0ICcuLi8uLi9zY3NzL3N0eWxlcyc7XG5AaW1wb3J0ICcuLi8uLi9zY3NzL2luY2x1ZGVzL2NvbG9ycy5zY3NzJztcblxuLnJpdmVyLXNlYXJjaCB7XG4gICAgcGFkZGluZy1sZWZ0OjE2JTtcbiAgICBwYWRkaW5nLXJpZ2h0OjE2JTtcbiAgICBwYWRkaW5nLWJvdHRvbToxNnB4O1xufVxuXG4ucml2ZXItbGlzdCB7XG4gICAgcGFkZGluZy1sZWZ0OjE2JTtcbiAgICBjb2x1bW4tY291bnQ6Mjtcbn1cbkBtZWRpYSBzY3JlZW4gYW5kIChtYXgtd2lkdGg6OTI0cHgpIHtcbiAgICAucml2ZXItbGlzdCB7XG4gICAgICAgIHBhZGRpbmctbGVmdDoxNiU7XG4gICAgICAgIGNvbHVtbi1jb3VudDoxO1xuICAgIH1cbn1cblxuLnJpdmVyLWxpc3QtZGF0YSB7XG4gICAgcGFkZGluZzogOHB4IDhweCA4cHggMHB4O1xufVxuLnJpdmVyLXNlYXJjaC1yZXN1bHQge1xuICAgIGNvbG9yOiRjMDQ7XG4gICAgY3Vyc29yOnBvaW50ZXI7XG4gICAgZm9udC13ZWlnaHQ6IGJvbGQ7XG5cbn1cbi5yaXZlci1zZWFyY2gtcmVzdWx0OmhvdmVyIHtcbiAgICBjb2xvcjokYzAyO1xufSIsIiRjMDA6IzA1MTI1MztcbiRjMDE6d2hpdGU7XG4kYzAyOiM5Njk2OTY7XG4kYzAzOiM2MzYzNjM7XG4kYzA0OiM1MzUzNTM7Il19 */"] });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](RiverListComponent, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"],
        args: [{
                selector: 'app-river-list',
                templateUrl: 'river-list.component.html',
                styleUrls: ['river-list.component.scss']
            }]
    }], function () { return [{ type: _services_river_data_service__WEBPACK_IMPORTED_MODULE_1__["RiverDataService"] }, { type: _auth_auth_service__WEBPACK_IMPORTED_MODULE_2__["AuthService"] }]; }, null); })();


/***/ }),

/***/ "./src/app/services/river-data.service.ts":
/*!************************************************!*\
  !*** ./src/app/services/river-data.service.ts ***!
  \************************************************/
/*! exports provided: RiverDataService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RiverDataService", function() { return RiverDataService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../environments/environment */ "./src/environments/environment.ts");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");




class RiverDataService {
    constructor(http) {
        this.http = http;
        this.getAllUSRivers = (partialName) => {
            if (!partialName) {
                return this.http.get(_environments_environment__WEBPACK_IMPORTED_MODULE_1__["environment"].baseUrl + "/api/rivers?code=" + _environments_environment__WEBPACK_IMPORTED_MODULE_1__["environment"].riverKeyCode).toPromise();
            }
            else {
                return this.http.get(_environments_environment__WEBPACK_IMPORTED_MODULE_1__["environment"].baseUrl + '/api/rivers?name=' + partialName + "&code=" + _environments_environment__WEBPACK_IMPORTED_MODULE_1__["environment"].riverKeyCode).toPromise();
            }
        };
        this.getRiverDetails = (riverCode) => {
            return this.http.get(_environments_environment__WEBPACK_IMPORTED_MODULE_1__["environment"].baseUrl + '/api/rivers/details/' + riverCode + "?code=" + _environments_environment__WEBPACK_IMPORTED_MODULE_1__["environment"].detailsKeyCode).toPromise();
        };
    }
}
RiverDataService.ɵfac = function RiverDataService_Factory(t) { return new (t || RiverDataService)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"])); };
RiverDataService.ɵprov = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({ token: RiverDataService, factory: RiverDataService.ɵfac });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](RiverDataService, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"]
    }], function () { return [{ type: _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"] }]; }, null); })();


/***/ }),

/***/ "./src/app/services/river-user.service.ts":
/*!************************************************!*\
  !*** ./src/app/services/river-user.service.ts ***!
  \************************************************/
/*! exports provided: RiverUserSerice */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RiverUserSerice", function() { return RiverUserSerice; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var src_environments_environment__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/environments/environment */ "./src/environments/environment.ts");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/__ivy_ngcc__/fesm2015/http.js");
/* harmony import */ var _auth_auth_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../auth/auth.service */ "./src/app/auth/auth.service.ts");





class RiverUserSerice {
    constructor(http, auth) {
        this.http = http;
        this.auth = auth;
        this.getActiveUser = () => {
            return this.activeUser;
        };
        this.postUserFavorite = (preference) => {
            return this.http.post(src_environments_environment__WEBPACK_IMPORTED_MODULE_1__["environment"].baseUrl + "/api/users", preference).toPromise();
        };
        this.getUserFavorites = (sub) => {
            return this.http.get(src_environments_environment__WEBPACK_IMPORTED_MODULE_1__["environment"].baseUrl + `/api/users/${sub}`).toPromise();
        };
        this.auth.userProfile$.subscribe(value => this.activeUser = value, err => console.error(err));
    }
}
RiverUserSerice.ɵfac = function RiverUserSerice_Factory(t) { return new (t || RiverUserSerice)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_auth_auth_service__WEBPACK_IMPORTED_MODULE_3__["AuthService"])); };
RiverUserSerice.ɵprov = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({ token: RiverUserSerice, factory: RiverUserSerice.ɵfac });
/*@__PURE__*/ (function () { _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵsetClassMetadata"](RiverUserSerice, [{
        type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"]
    }], function () { return [{ type: _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"] }, { type: _auth_auth_service__WEBPACK_IMPORTED_MODULE_3__["AuthService"] }]; }, null); })();


/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
const environment = {
    production: false,
    baseUrl: 'http://localhost:4200',
    riverKeyCode: '',
    detailsKeyCode: '',
    auth0Domain: 'brgs.auth0.com',
    auth0ClientId: 'UjY1xSZt2XT8Fn2kXgmneO7moLILNtB2',
    openIdScope: 'openid email profile'
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/__ivy_ngcc__/fesm2015/platform-browser.js");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_1__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
_angular_platform_browser__WEBPACK_IMPORTED_MODULE_3__["platformBrowser"]().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(err => console.error(err));


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! /Users/luke/Documents/workspace/brgs/whitewaterfinder/whitewaterfinder.pwa/paddle-finder/src/main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map