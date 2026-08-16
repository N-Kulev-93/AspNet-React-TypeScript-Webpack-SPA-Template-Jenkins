import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import App from './App';
import './App.css';

const domNode = document.getElementById('root');
if (!domNode) {
    throw new Error("Missing root node!")
}

const root = createRoot(domNode);
root.render(
    <StrictMode>
        <App />
        </StrictMode>);