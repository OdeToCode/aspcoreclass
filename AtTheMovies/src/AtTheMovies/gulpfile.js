/// <binding AfterBuild='copy' />
"use strict";

var gulp = require("gulp");

gulp.task("copy", function() {
    gulp.src("node_modules/bootstrap/dist/**")
        .pipe(gulp.dest("wwwroot/css"));
});

gulp.task("default", ["copy"]);