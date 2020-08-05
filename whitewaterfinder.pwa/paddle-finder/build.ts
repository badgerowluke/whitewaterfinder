import { writeFile } from 'fs'
const colors = require('colors');
require('dotenv').config();
// require('dotenv').load();
console.log(colors.green("hello world"))

const targetPath = './src/environments/environment.ts';

// `environment.ts` file structure
const envConfigFile = `export const environment = {
    production: ${process.env.production},
    baseUrl: '${process.env.baseUrl}',
    riverKeyCode: '',
    detailsKeyCode:'',
    auth0Domain: '${process.env.auth0Domain}',
    auth0ClientId: '${process.env.auth0ClientId}',
    openIdScope: '${process.env.openIdScope}',
    callbackUrl: '${process.env.callbackUrl}'
 };
 `;

 writeFile(targetPath, envConfigFile, function (err) {
    if (err) {
        throw console.error(err);
    } else {
        console.log(colors.magenta(`Angular environment.ts file generated correctly at ${targetPath} \n`));
    }
 });