import eslintReact from "@eslint-react/eslint-plugin";
import { defineConfig } from "eslint/config";
import tseslint from "typescript-eslint";

export default defineConfig(
    {
        basePath: "src",
        files: ["**/*.ts", "**/*.tsx"],
        linterOptions: {
            reportUnusedDisableDirectives: true
        },
        extends: [
            tseslint.configs.recommended,
            eslintReact.configs["recommended-typescript"],
        ],
        languageOptions: {
            parser: tseslint.parser,
            sourceType: "module",
            parserOptions: {
                ecmaVersion: 2022,
                projectService: true,
                tsconfigRootDir: import.meta.dirname,
            },
        },
        settings: {
            react: {
                version: "detect"
            }
        },
        rules: {
            "@eslint-react/no-missing-key": "warn"
        },
    },
);