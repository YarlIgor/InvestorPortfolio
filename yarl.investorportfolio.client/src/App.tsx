import {
  BrowserRouter as Router,
  Route,
  Routes,
  Navigate,
} from "react-router-dom";
import "./App.css";
import Investors from "./components/investors/Investors";
import Commitments from "./components/commitments/Commitments";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Navigate replace to="/investors" />} />
        <Route path="/investors" element={<Investors />} />
        <Route
          path="/investors/:investorId/commitments"
          element={<Commitments />}
        />
      </Routes>
    </Router>
  );
}

export default App;
