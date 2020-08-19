import { writeFile, mkdir, existsSync } from 'fs'
const colors = require('colors');
require('dotenv').config();
// require('dotenv').load();
console.log(colors.green("hello world"))

const targetPath = './src/environments/environment.ts';

// `environment.ts` file structure
const envConfigFile = `export const environment = {
    production: ${process.env.production},
    baseUrl: '${process.env.baseUrl}',
    apiUrl: '${process.env.apiUrl}',
    riverKeyCode: '',
    detailsKeyCode:'',
    auth0Domain: '${process.env.auth0Domain}',
    auth0ClientId: '${process.env.auth0ClientId}',
    openIdScope: '${process.env.openIdScope}',
    callbackUrl: '${process.env.callbackUrl}',
    subscriptionKey: '${process.env.subscriptionKey}'
 };
 `;

 if(existsSync('./src/environments')) {
    writeFile(targetPath, envConfigFile, function (err) {
        if (err) {
            throw console.error(err);
        } else {
            console.log(colors.magenta(`Angular environment.ts file generated correctly at ${targetPath} \n`));
        }
     });
 } else {
     mkdir('./src/environments',(err) =>{
        if(err) {
            console.log(colors.red(err));
        }
        console.log(colors.green("created environments folder"));
        writeFile(targetPath, envConfigFile, function (err) {
           if (err) {
               throw console.error(err);
           } else {
               console.log(colors.magenta(`Angular environment.ts file generated correctly at ${targetPath} \n`));
           }
        });
     })

 }