/// <binding BeforeBuild='sass, sass-admin' />
var gulp = require("gulp"),
    fs = require("fs"),
    less = require("gulp-less"),
    sass = require("gulp-sass");

// other content removed
gulp.task("sass", function () {
    return gulp.src('Styles/main.scss')
        .pipe(sass())
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task("sass-admin", function () {
    return gulp.src('Styles/Admin/paper-dashboard.scss')
        .pipe(sass())
        .pipe(gulp.dest('wwwroot/css/Admin'));
});

