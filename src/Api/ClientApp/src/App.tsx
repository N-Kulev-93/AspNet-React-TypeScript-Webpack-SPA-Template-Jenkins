import { useState } from 'react';
import '.'

const App = () => {
    const [number, setNumber] = useState<number>();

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>): void => {
        const id = Number(event.currentTarget.value);
        setNumber(id);
    }
    const handleClick = (): Promise<void> => {
        return Promise.resolve();
    }

    return (
        <div className="centered-container">
            <h2>Welcome to fat cats family fetching service! </h2> {/* TODO: complete template http action example... */}
            <input type="number" value={number} onChange={handleChange} />
            <button onClick={handleClick}>Fetch</button>
        </div>
    );
}
    
export default App;
