/// <binding AfterBuild='default' />
"use strict";

var gulp = require("gulp");

gulp.task("copy:css", function() {
    return gulp.src("node_modules/bootstrap/dist/**")
               .pipe(gulp.dest("wwwroot/css")); 
});

gulp.task("copy:js",
    function() {
        return gulp.src("node_modules/angular/angular.js")
            .pipe(gulp.dest("wwwroot/js"));
    });

gulp.task("default", ["copy:css", "copy:js"]);