// For this project, use this file and task runner load all libraries to Scripts/libs folder.
// /// <binding AfterBuild='copyExDialogImages' />

var gulp = require('gulp');
// del enable us to delete files (del replaces the old rimraf).
var del = require('del'); 

// Defining some handy paths
var paths = {
    npmInstall: "./node_modules/",
    npmClient: "../angular-debug/npm-libs/"
};
////copyLibs config example.
//const copyLibsConfig = {
//    src: dir.src + 'images/**/*',
//    build: dir.build + 'images/',

//    minOpts: {
//        optimizationLevel: 5
//    }
//};

// To make all the Angular application relevant packages accessible to the browser, we need to copy
// the packages from node_modules to wwwroot\libs.
function copyLibs() {
    return new Promise(function (resolve, reject) { 
        //Using copied js files only avoids loading a large amount of unnecessary dependent and ts files.
        gulp.src(paths.npmInstall + '@angular/**/*.js').pipe(gulp.dest(paths.npmClient + '@angular'));        
        gulp.src(paths.npmInstall + 'rxjs/**/*.js').pipe(gulp.dest(paths.npmClient + 'rxjs'));
        gulp.src(paths.npmInstall + 'tslib/*.js').pipe(gulp.dest(paths.npmClient + 'tslib'));

        //These for systemjs-dependent libs are directly loaded from node-modules or files.
        //gulp.src(paths.npmInstall + 'core-js/**/*.js').pipe(gulp.dest(paths.npmClient + 'core-js'));
        //gulp.src(paths.npmInstall + 'zone.js/**/*.js').pipe(gulp.dest(paths.npmClient + 'zone.js'));
        //gulp.src(paths.npmInstall + 'systemjs/**/*.js').pipe(gulp.dest(paths.npmClient + 'systemjs'));
        //gulp.src(paths.npmInstall + 'reflect-metadata/**/*.js').pipe(gulp.dest(paths.npmClient + 'reflect-metadata'));

        resolve();
    });    
}
//exports.copyLibs = copyLibs;
exports.copyLibs = gulp.series(clean, copyLibs);

function clean() {
    return del([paths.npmClient], { force: true });
}
exports.clean = clean;

////watch example.
//function watch(done) {
//    // image changes
//    gulp.watch(imgConfig.src, images);
//    // CSS changes
//    gulp.watch(cssConfig.watch, css);
//    done();
//}

// We don't need this 'default' task especially when using Visual Studio, however it is common to
// start off the main task chain using a task called 'default'.
// (if you write gulp at the command prompt, the gulp command will look for a task named 'default' and start it if it finds it).
//exports.default = gulp.series(exports.copyLibs, watch);
exports.default = gulp.series(exports.copyLibs);